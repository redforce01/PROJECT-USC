using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class CharacterController : MonoBehaviour
    {
        public CharacterBase character;
        public LayerMask interactionLayer;
        public InteractionUI interactionUI;

        private IInteractable[] interactableObjects;


        private void Awake()
        {
            character = GetComponent<CharacterBase>();
        }

        private void Start()
        {
            InputSystem.Instance.OnClickSpace += CommandJump;
            InputSystem.Instance.OnClickLeftMouseButton += CommandAttack;
            InputSystem.Instance.OnClickInteract += CommandInteract;
            InputSystem.Instance.OnMouseScrollWheel += CommandMouseScrollWheel;
            InputSystem.Instance.OnClickThrowButton += CommandThrow;
        }

        public Transform throwStartPivot;
        public GameObject throwObjectPrefab;
        public LineRenderer throwGuideLineRenderer;
        private GameObject throwGuideObject;
        private bool isThrowMode = false;
        public int guideStep = 30;
        public float throwPower = 10f;
        public float throwAngle = 45f;

        public void CommandThrow()
        {
            if (isThrowMode)
            {
                isThrowMode = false;
                //TODO : Throw Execute(����) �ڵ� �ۼ�
            }
            else
            {
                isThrowMode = true;
                throwGuideObject = Instantiate(throwObjectPrefab, transform);
                throwGuideObject.gameObject.SetActive(true);
                throwGuideObject.transform.SetPositionAndRotation(
                    throwStartPivot.transform.position, 
                    throwStartPivot.transform.rotation);
                Rigidbody guideObjectRigidbody = throwGuideObject.GetComponent<Rigidbody>();
                guideObjectRigidbody.isKinematic = true;

                //TODO : ���̵� ������ �����ִ� �ڵ� �ۼ�
                // Power : ��
                // Angle : ����
                float power = throwPower;
                throwGuideLineRenderer.positionCount = guideStep;
                for (int i = 0; i < guideStep; i++)
                {
                    Vector3 result = CalculateThrowAsTime(power, i * 30f * Time.deltaTime);
                    throwGuideLineRenderer.SetPosition(i, result);
                }
            }
        }

        public Vector3 CalculateThrowAsTime(float power, float time)
        {
            float z = power * Mathf.Cos(throwAngle * Mathf.Deg2Rad) * time;
            float y = power * Mathf.Sin(throwAngle * Mathf.Deg2Rad) * time;

            float gravity = 9.81f;
            double newY = y - (0.5 * gravity * Mathf.Pow(time, 2));

            Vector3 result = throwStartPivot.localPosition + new Vector3(0, (float)newY, z);
            result.x = 0;

            return result;
        }

        public void CommandMouseScrollWheel(float delta)
        {
            if (delta > 0)
            {
                interactionUI.SelectPrev();
            }
            else if (delta < 0)
            {
                interactionUI.SelectNext();
            }
        }

        private void CommandInteract()
        {
            if (interactableObjects != null && interactableObjects.Length > 0)
            {
                interactionUI.Execute();
                //interactableObjects[0].Interact();
            }
        }

        public void CheckOverlapInteractionObject()
        {
            Collider[] overlappedObjects = Physics.OverlapSphere(
                character.transform.position, 2f, interactionLayer, QueryTriggerInteraction.Collide);

            List<IInteractable> interactables = new List<IInteractable>();
            for (int i = 0; i < overlappedObjects.Length; i++)
            {
                if (overlappedObjects[i].TryGetComponent(out IInteractable interaction))
                {
                    interactables.Add(interaction);
                }
            }
            interactableObjects = interactables.ToArray();

            interactionUI.SetInteractableObjects(interactableObjects);
        }

        private void Update()
        {
            CheckOverlapInteractionObject();

            character.Move(InputSystem.Instance.Movement);
            character.Rotate(InputSystem.Instance.Look.x);
            character.SetRunning(InputSystem.Instance.IsLeftShift);
        }

        private void CommandJump()
        {
            character.Jump();
        }

        private void CommandAttack()
        {
            character.Attack();
        }
    }
}

