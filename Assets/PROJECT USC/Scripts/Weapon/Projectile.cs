using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class Projectile : MonoBehaviour
    {
        public float lifeTime; // �Ѿ��� Ȱ��ȭ �ǰ�, ����ִ� ���� �ð�[���� �ð�]
        public float speed; // �Ѿ��� �ӵ�


        private void Start()
        {
            Destroy(gameObject, lifeTime); // ���� GameObject�� LifeTime ���Ŀ� �ı� �ǵ��� ���
        }

        private void Update()
        {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        }

        private void OnCollisionEnter(Collision collision)
        {
            //TODO : �浹 �� � ������Ʈ�� �ε��ƴ°�?
            // => ����/�Ǵ�
            //  => �Ϲ� ������Ʈ�̸� ����Ʈ�� ��� || ĳ���� ������Ʈ�̸� �������� �ش� + ����Ʈ ���

            Debug.Log(
                "<color=yellow> Bullet Impact !! </color> " +
                $"name : <color=red>{collision.gameObject.name}</color>");

            Destroy(gameObject);
        }
    }
}
