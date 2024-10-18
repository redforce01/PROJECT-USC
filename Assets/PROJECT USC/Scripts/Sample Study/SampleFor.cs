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

            // 결과 예상 값 : Hello, Sample World 가 repeatCount 값 만큼, 반복 출력 됨
            for (int i = 0; i < repeatCount; i++)
            {
                Debug.Log(comment);
            }

            // for 반복문의 구조 :
            // => "int i = 0;" => 이 부분을 초기화 부분이라고 함         => 초기화
            // => "i < repeatCount; " => 이 부분을 조건식 부분이라고 함  => 조건식
            // => "i++" => 이 부분을 증감식 부분이라고 함                => 증감식

            // 구구단 출력하는 코드
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


