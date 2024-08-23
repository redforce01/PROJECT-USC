using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class InputSystem : MonoBehaviour
    {
        void Update()
        {
            // Input.GetKey 는 Keycode의 Key를 계속 누르고 있으면 True => 누르고 있으면 계속 TRUE
            // Input.GetKeyDown 은 Keycode의 Key를 누르는 순간 True => 누르는 순간 딱 1번만 TRUE
            // Input.GetKeyUp 은 Keycode의 Key를 누르고 뗄 때 True => 누르고 뗄 때 딱 1번만 TRUE

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

            // Input.GetMouseButton(0) 에서 "0" 의 의미는 마우스 LeftButton을 의미한다.
            //  => 0 : Left Button, 1 : Right Button, 2 : Middle Button
            // Input.GetMouseButton(0) 은 Left Button이 Pressed 되어 있으면 True
            // Input.GetMouseButtonDown(0) 은 Left Button이 Down 될 때 딱 1번만 True
            // Input.GetMouseButtonUp(0) 은 Left Button이 Up 될 때 딱 1번만 True

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


            // Input.GetAxis("Horizontal") 은 Horizontal 방향의 값(A or D)을 의미한다.
            // Input.GetAxis("Vertical") 은 Vertical 방향의 값(W or S)을 의미한다.
            // TopMenu > Edit > Project Settings 팝업 > Input Manager > Axes 에서 Horizontal, Vertical을 확인할 수 있다.

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Debug.Log("Horizontal: " + horizontal);
            Debug.Log("Vertical: " + vertical);
        }
    }
}

