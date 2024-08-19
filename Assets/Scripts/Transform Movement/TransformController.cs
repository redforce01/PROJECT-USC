using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class TransformController : MonoBehaviour
    {
        public float speed = 5.0f;

        private void Update()
        {
            // ���࿡, Keycode ��, W Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.W))
            {
                // Transform�� Position �����ٰ� += �ؼ� Vector3.forward * speed * Time.deltaTime ��ŭ �̵���Ų��.
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            // ���࿡, Keycode ��, S Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.S))
            {
                // Transform�� Position �����ٰ� += �ؼ� Vector3.back * speed * Time.deltaTime ��ŭ �̵���Ų��.
                transform.position += Vector3.back * speed * Time.deltaTime;
            }

            // ���࿡, Keycode ��, A Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.A))
            {
                // Transform�� Position �����ٰ� += �ؼ� Vector3.left * speed * Time.deltaTime ��ŭ �̵���Ų��.
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            // ���࿡, Keycode ��, D Ű�� ���� �����̸�?
            if (Input.GetKey(KeyCode.D))
            {
                // Transform�� Position �����ٰ� += �ؼ� Vector3.right * speed * Time.deltaTime ��ŭ �̵���Ų��.
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}


