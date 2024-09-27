using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class CharacterBase : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, sensorRadius);

            for (int i = 0; i < detectedObjects.Count; i++)
            {
                Gizmos.color = Color.green;
                Vector3 startPos = transform.position + Vector3.up;
                Vector3 endPos = detectedObjects[i].transform.position;

                Gizmos.DrawLine(startPos, endPos);
            }
        }

        public float sensorRadius = 1f;
        public Collider[] overlappedObjects;
        public LayerMask sensorLayer;
        public List<Collider> detectedObjects = new List<Collider>();
        public float sensorAngle = 90f;

        public Animator characterAnimator;
        public CharacterStatData characterStat;

        public Vector2 movement;
        public Vector2 movementBlend;
        public float rotation = 0f;
        public bool isRunning = false;
        public float runningBlend;

        private void Awake()
        {
            characterAnimator = GetComponent<Animator>();
        }

        private void Update()
        {   
            overlappedObjects = Physics.OverlapSphere(transform.position, sensorRadius, sensorLayer);
            detectedObjects.Clear();
            for (int i = 0; i < overlappedObjects.Length; i++)
            {
                Vector3 direction = overlappedObjects[i].transform.position - transform.position;
                float dot = Vector3.Dot(transform.forward.normalized, direction.normalized);
                if (dot > Mathf.Cos(sensorAngle * 0.5f * Mathf.Deg2Rad))
                {
                    Vector3 rayStartPos = transform.position + Vector3.up;
                    Vector3 rayDirection = overlappedObjects[i].transform.position - transform.position;
                    rayDirection.y = 0;

                    if (Physics.Raycast(rayStartPos, rayDirection, out RaycastHit hitInfo, sensorRadius, sensorLayer))
                    {
                        if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Character"))
                        {
                            detectedObjects.Add(overlappedObjects[i]);
                        }
                    }
                }                
            }

            CheckGround();
            FreeFall();

            Vector3 moveVec = new Vector3(movementBlend.x, verticalVelocity, movementBlend.y);

            float targetSpeed = isRunning ? characterStat.RunSpeed : characterStat.WalkSpeed;
            transform.Translate(targetSpeed * moveVec * Time.deltaTime, Space.Self);

            runningBlend = Mathf.Lerp(runningBlend, isRunning ? 1f : 0f, Time.deltaTime * 10f);

            // Movement Blend : �� �̿��ϴ� ������ �ִϸ��̼ǿ� ������ parameter ���� ���ڱ� Ƣ�� �ʵ���
            // �ϱ� ���ؼ� �߰�(����)���� ���ؼ� ������ ����
            movementBlend = Vector2.Lerp(movementBlend, movement, Time.deltaTime * 10f);

            characterAnimator.SetFloat("Magnitude", movementBlend.magnitude);
            characterAnimator.SetFloat("Horizontal", movementBlend.x);
            characterAnimator.SetFloat("Vertical", movementBlend.y);
            characterAnimator.SetFloat("RunningBlend", runningBlend);
        }

        public void Move(Vector2 input)
        {
            movement = input;
        }


        public void Rotate(float angle)
        {
            rotation += angle;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        public void SetRunning(bool isRun)
        {
            isRunning = isRun;
        }

        [Header("Jump Setting")]
        public float jumpForce;
        public float verticalVelocity;
        public bool isGrounded;
        public float jumpTimeout;
        public float jumpTimeoutDelta;

        public float groundOffset;
        public float groundRadius;
        public LayerMask groundLayer;

        public void Jump()
        {
            if (isGrounded == false || jumpTimeoutDelta > 0f)
                return;

            verticalVelocity = jumpForce;
            jumpTimeoutDelta = jumpTimeout;

            // Todo: �����ϴ� �ִϸ��̼� �����ϴ� ó��
            characterAnimator.SetTrigger("JumpTrigger");
        }

        public void FreeFall()
        {
            jumpTimeoutDelta -= Time.deltaTime;
            if (isGrounded == false)
            {
                verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                if (jumpTimeoutDelta > 0)
                {
                   
                }
                else
                {
                    verticalVelocity = 0f;
                }
            }
        }

        public void CheckGround()
        {
            Vector3 spherePosition = transform.position + (Vector3.down * groundOffset);
            isGrounded = Physics.CheckSphere(spherePosition, groundRadius, groundLayer, QueryTriggerInteraction.Ignore);

            // Todo : ĳ���Ͱ� �����ִٰ� �ִϸ��������� �˷��ִ� ó��
            characterAnimator.SetBool("IsGrounded", isGrounded);
        }

        public void Attack()
        {
            characterAnimator.SetTrigger("AttackTrigger");
        }
    }
}

