using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class InputSystem : MonoBehaviour
    {
        void Update()
        {
            // Input.GetKey �� Keycode�� Key�� ��� ������ ������ True => ������ ������ ��� TRUE
            // Input.GetKeyDown �� Keycode�� Key�� ������ ���� True => ������ ���� �� 1���� TRUE
            // Input.GetKeyUp �� Keycode�� Key�� ������ �� �� True => ������ �� �� �� 1���� TRUE

            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Space Key is Pressed");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space Key is Down");
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("Space Key is Up");
            }

            // Input.GetMouseButton(0) ���� "0" �� �ǹ̴� ���콺 LeftButton�� �ǹ��Ѵ�.
            //  => 0 : Left Button, 1 : Right Button, 2 : Middle Button
            // Input.GetMouseButton(0) �� Left Button�� Pressed �Ǿ� ������ True
            // Input.GetMouseButtonDown(0) �� Left Button�� Down �� �� �� 1���� True
            // Input.GetMouseButtonUp(0) �� Left Button�� Up �� �� �� 1���� True

            if (Input.GetMouseButton(0))
            {
                Debug.Log("Mouse Button 0 is Pressed");
            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse Button 0 is Down");
            }

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Mouse Button 0 is Up");
            }


            // Input.GetAxis("Horizontal") �� Horizontal ������ ��(A or D)�� �ǹ��Ѵ�.
            // Input.GetAxis("Vertical") �� Vertical ������ ��(W or S)�� �ǹ��Ѵ�.
            // TopMenu > Edit > Project Settings �˾� > Input Manager > Axes ���� Horizontal, Vertical�� Ȯ���� �� �ִ�.

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Debug.Log("Horizontal: " + horizontal);
            Debug.Log("Vertical: " + vertical);
        }
    }
}

