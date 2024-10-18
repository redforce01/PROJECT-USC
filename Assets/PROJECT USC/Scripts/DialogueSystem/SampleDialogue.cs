using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class SampleDialogue : MonoBehaviour
    {
        public bool isWaitInput = false;

        public string questionMessage;

        public string[] answerGroup_1;
        public string[] answerGroup_2;
        public string[] answerGroup_3;

        private void Start()
        {
            ShowQuestion();
        }

        private void Update()
        {
            if (isWaitInput == true)
            {
                bool isInputTaken = false;

                // To do : 1,2,3��Ű �Է��� �޴� �κ��� �����غ���.
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    // 1�� �׷쿡�� ������ ���� ����Ѵ�.
                    int random = Random.Range(0, answerGroup_1.Length);
                    Debug.Log(answerGroup_1[random]);

                    isInputTaken = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    // 2�� �׷쿡�� ������ ���� ����Ѵ�.
                    int random = Random.Range(0, answerGroup_2.Length);
                    Debug.Log(answerGroup_2[random]);

                    isInputTaken = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    // 3�� �׷쿡�� ������ ���� ����Ѵ�.
                    int random = Random.Range(0, answerGroup_3.Length);
                    Debug.Log(answerGroup_3[random]);

                    isInputTaken = true;
                }

                // To do : Space Ű �Է��� ������ 1,2,3�� ������ ������ ����ϰ�, isWaitInput�� false �� �����Ѵ�.
                if (isInputTaken)
                {
                    isWaitInput = false;
                    ShowQuestion();
                }
            }
        }

        public void ShowQuestion()
        {
            Debug.Log(questionMessage);
            isWaitInput = true;
        }
    }
}

