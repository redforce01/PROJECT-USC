using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class CharacterController : MonoBehaviour
    {
        public CharacterBase character;

        private void Awake()
        {
            character = GetComponent<CharacterBase>();
        }

        private void Start()
        {
            InputSystem.Instance.OnClickSpace += CommandJump;
            InputSystem.Instance.OnClickLeftMouseButton += CommandAttack;
        }

        private void Update()
        {
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

