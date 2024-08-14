using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySampleCode
{
    public class SampleFor : MonoBehaviour
    {
        public int repeatCount; // => 10

        void Start()
        {
            string comment = "Hello, Sample World";

            // ��� ���� �� : Hello, Sample World �� repeatCount �� ��ŭ, �ݺ� ��� ��
            for (int i = 0; i < repeatCount; i++)
            {
                Debug.Log(comment);
            }

            // for �ݺ����� ���� :
            // => "int i = 0;" => �� �κ��� �ʱ�ȭ �κ��̶�� ��         => �ʱ�ȭ
            // => "i < repeatCount; " => �� �κ��� ���ǽ� �κ��̶�� ��  => ���ǽ�
            // => "i++" => �� �κ��� ������ �κ��̶�� ��                => ������

            // ������ ����ϴ� �ڵ�
            for (int x = 1; x < 10; x++)
            {
                for (int y = 1; y < 10; y++)
                {
                    Debug.LogFormat("{0} x {1} = {2}", x, y, x * y);
                }
            }

        }
    }
}


