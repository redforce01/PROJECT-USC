using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class SampleDialogue_2 : MonoBehaviour
    {
        public int strikeCount = 5;
        public float currentHP = 100.0f;
        public float damageMin = 3.0f;
        public float damageMax = 10.0f;

        private void Start()
        {
            ShowRemainHP();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1)) // 1: ���콺 �� Ŭ��(Right Button)
            {
                Attack();
            }
        }

        public void Attack()
        {
            Debug.Log("���� ����");
            for (int i = 0; i < strikeCount; i++)
            {
                float randomDamage = Random.Range(damageMin, damageMax);
                currentHP -= randomDamage;
                ShowRemainHP();
            }
            Debug.Log("���� ��");
        }

        public void ShowRemainHP()
        {
            Debug.Log("���� HP : " + currentHP);
        }
    }
}

