using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class MineGimmick : MonoBehaviour
    {
        public float damage;
        public float timer;
        public bool isCountDown;

        public GameObject explosionObject;

        private IEnumerator coroutine;

        private void Update()
        {
            if (isCountDown)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    // To do : Explosion => Damage To Near Player
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject newEffect = Instantiate(
                            explosionObject, 
                            transform.position + Vector3.up, 
                            Quaternion.identity);

                        newEffect.SetActive(true);
                    }

                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.CompareTag("Player"))
            {
                isCountDown = true;
                timer = 3f;

                coroutine = CountDown();
                StartCoroutine(coroutine);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.root.CompareTag("Player"))
            {
                isCountDown = false;
                timer = 3f;
                MeshRenderer renderer = GetComponent<MeshRenderer>();
                renderer.material.color = Color.white;

                StopCoroutine(coroutine);
            }
        }

        IEnumerator CountDown()
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            bool isColorful = false;

            // While 문(반복문) : ( ) 안의 조건이 참이면 { } 안의 코드를 계속 반복한다.
            while (timer > 0 && isCountDown)
            {
                renderer.material.color = isColorful ? Color.red : Color.white;
                isColorful = !isColorful;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}

