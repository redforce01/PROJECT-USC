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
            // ���࿡, Keycode ��, W Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.W))
            {
                // Transform�� Position �����ٰ� += �ؼ� Vector3.forward * speed * Time.deltaTime ��ŭ �̵���Ų��.
                transform.position += transform.forward * speed * Time.deltaTime;
            }

            // ���࿡, Keycode ��, S Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.S))
            {
                // Transform�� Position �����ٰ� += �ؼ� Vector3.back * speed * Time.deltaTime ��ŭ �̵���Ų��.
                transform.position -= transform.forward * speed * Time.deltaTime;
            }

            // ���࿡, Keycode ��, A Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.A))
            {
                // Transform�� Position �����ٰ� += �ؼ� Vector3.left * speed * Time.deltaTime ��ŭ �̵���Ų��.
                transform.position -= transform.right * speed * Time.deltaTime;
            }

            // ���࿡, Keycode ��, D Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.D))
            {
                // Transform�� Position �����ٰ� += �ؼ� Vector3.right * speed * Time.deltaTime ��ŭ �̵���Ų��.
                transform.position += transform.right * speed * Time.deltaTime;
            }

            // ���࿡ Keycode �� Q Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.Q))
            {
                // Rotation Y ���� ���ҽ�Ų��.
                rotationY--;

                // Rotation Y ���� Transform�� Rotation ������ �����Ѵ�.
                transform.rotation = Quaternion.Euler(0, rotationY, 0); 
            }

            if (Input.GetKey(KeyCode.E))
            {
                // Rotation Y ���� ������Ų��.
                rotationY++;

                // Rotation Y ���� Transform�� Rotation ������ �����Ѵ�.
                transform.rotation = Quaternion.Euler(0, rotationY, 0);
            }
        }
    }
}


