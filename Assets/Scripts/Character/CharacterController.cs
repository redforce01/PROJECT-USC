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

