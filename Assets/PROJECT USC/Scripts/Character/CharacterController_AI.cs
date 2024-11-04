using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public enum AIState
    {
        Peaceful,
        Battle,
    }

    public class CharacterController_AI : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);

            if (aiState == AIState.Battle && target != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, target.transform.position);
            }

            if (aiState == AIState.Peaceful && patrolWaypoints.Count > 0)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, patrolWaypoints[currentWaypointIndex].position);
            }
        }

        public CharacterBase linkedCharacter;
        public UnityEngine.AI.NavMeshAgent navAgent;

        public AIState aiState = AIState.Peaceful;
        public float detectionRadius = 10f;
        public LayerMask detectionLayers;
                
        public List<Transform> patrolWaypoints = new List<Transform>();
        public int currentWaypointIndex = 0;

        public CharacterBase target = null;

        private void Awake()
        {
            linkedCharacter = GetComponent<CharacterBase>();
            navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            navAgent.updateRotation = false;
        }

        private void Start()
        {
            navAgent.speed = linkedCharacter.moveSpeed;
            linkedCharacter.SetArmed(true);
        }

        private void Update()
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                OnArrivedDestination();
            }

            if (navAgent.hasPath)
            {
                Vector3 moveDirection = (navAgent.steeringTarget - transform.position).normalized;
                Vector2 input = new Vector2(moveDirection.x, moveDirection.z);

                linkedCharacter.Move(input, 0);
            }

            UpdateDetecting();
            UpdateCombat();
        }

        private void UpdateCombat()
        {
            if (aiState != AIState.Battle || target == null)
                return;

            float distance = Vector3.Distance(transform.position, target.transform.position);
            float weaponRange = 7f;
            if (distance > weaponRange)
            {
                ChaseTarget();
                linkedCharacter.Shoot(false);
            }
            else
            {
                // TODO : Attack
                float differAngle = Vector3.Angle(transform.forward, target.transform.position - transform.position);
                linkedCharacter.Rotate(differAngle);
                linkedCharacter.AimingPoint = target.transform.position;
                linkedCharacter.Shoot(true);
            }
        }

        private void UpdateDetecting()
        {
            if (aiState != AIState.Peaceful)
                return;

            Collider[] detectionColliders = Physics.OverlapSphere(
                transform.position,
                detectionRadius,
                detectionLayers,
                QueryTriggerInteraction.Ignore);

            if (detectionColliders.Length <= 0)
                return;

            for (int i = 0; i < detectionColliders.Length; i++)
            {
                if (detectionColliders[i].transform.root.TryGetComponent(out CharacterBase character))
                {
                    if (character.gameObject.CompareTag("Player"))
                    {
                        target = character;
                        aiState = AIState.Battle;
                        ChaseTarget();
                        break;
                    }
                }
            }
        }

        public void SetDestination(Vector3 destination)
        {
            navAgent.SetDestination(destination);
        }

        public void OnArrivedDestination()
        {
            MoveToNextWaypoint();
        }

        public void MoveToNextWaypoint()
        {
            if (patrolWaypoints.Count <= 0)
                return;

            currentWaypointIndex++;
            if (currentWaypointIndex >= patrolWaypoints.Count)
                currentWaypointIndex = 0;

            SetDestination(patrolWaypoints[currentWaypointIndex].position);
        }

        public void ChaseTarget()
        {
            if (target == null)
                return;

            float distance = Vector3.Distance(transform.position, target.transform.position);
            float weaponRange = 7f;
            if (distance > weaponRange)
            {
                SetDestination(target.transform.position);
            }
            else
            {
                SetDestination(transform.position);
            }
        }
    }
}
