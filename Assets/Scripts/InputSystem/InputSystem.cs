using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace USC
{
    public class InputSystem : MonoBehaviour
    {
        public static InputSystem Instance { get; private set; }

        public Vector2 Movement => movement;
        public Vector2 Look => look;
        public bool IsLeftShift => isLeftShift;

        private Vector2 movement;
        private Vector2 look;
        private bool isLeftShift;
        private bool isShowCursor = false;

        public System.Action OnClickSpace;
        public System.Action OnClickLeftMouseButton;

        private void Awake()
        {
            Instance = this;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClickLeftMouseButton?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnClickSpace?.Invoke();
            }

            isShowCursor = Input.GetKey(KeyCode.LeftAlt);
            if (isShowCursor)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            movement = new Vector2(inputX, inputY);

            float lookX = Input.GetAxis("Mouse X");
            float lookY = Input.GetAxis("Mouse Y");
            look = isShowCursor ? Vector2.zero : new Vector2(lookX, lookY);

            isLeftShift = Input.GetKey(KeyCode.LeftShift);
        }
    }
}

