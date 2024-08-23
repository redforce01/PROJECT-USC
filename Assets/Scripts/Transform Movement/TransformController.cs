using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class TransformController : MonoBehaviour
    {
        public float speed = 5.0f;
        public float rotationY = 0;

        private void Update()
        {
            // 만약에, Keycode 상, W 키를 누른 상태이면?
            if (Input.GetKey(KeyCode.W))
            {
                // Transform의 Position 값에다가 += 해서 Vector3.forward * speed * Time.deltaTime 만큼 이동시킨다.
                transform.position += transform.forward * speed * Time.deltaTime;
            }

            // 만약에, Keycode 상, S 키를 누른 상태이면?
            if (Input.GetKey(KeyCode.S))
            {
                // Transform의 Position 값에다가 += 해서 Vector3.back * speed * Time.deltaTime 만큼 이동시킨다.
                transform.position -= transform.forward * speed * Time.deltaTime;
            }

            // 만약에, Keycode 상, A 키를 누른 상태이면?
            if (Input.GetKey(KeyCode.A))
            {
                // Transform의 Position 값에다가 += 해서 Vector3.left * speed * Time.deltaTime 만큼 이동시킨다.
                transform.position -= transform.right * speed * Time.deltaTime;
            }

            // 만약에, Keycode 상, D 키를 누른 상태이면?
            if (Input.GetKey(KeyCode.D))
            {
                // Transform의 Position 값에다가 += 해서 Vector3.right * speed * Time.deltaTime 만큼 이동시킨다.
                transform.position += transform.right * speed * Time.deltaTime;
            }

            // 만약에 Keycode 상 Q 키를 누른 상태이면?
            if (Input.GetKey(KeyCode.Q))
            {
                // Rotation Y 값을 감소시킨다.
                rotationY--;

                // Rotation Y 값을 Transform의 Rotation 값으로 적용한다.
                transform.rotation = Quaternion.Euler(0, rotationY, 0); 
            }

            if (Input.GetKey(KeyCode.E))
            {
                // Rotation Y 값을 증가시킨다.
                rotationY++;

                // Rotation Y 값을 Transform의 Rotation 값으로 적용한다.
                transform.rotation = Quaternion.Euler(0, rotationY, 0);
            }
        }
    }
}


