using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleOperator : MonoBehaviour
{
    public int sampleA = 0;
    public int sampleB = 0;
    public int result = 0;

    public bool flagA = true;
    public bool flagB = false;

    void Start()
    {
        // result = sampleA / sampleB; // +, -, *, /, %
        // result += sampleA; // result = result * sampleA; // =, +=, -=, *=, /=, %=
        // result++; result--; // ++, --

        //if (flagA && !flagB) // && : and (그리고), || : or (또는), ! : not (아니다)
        //{
        //    Debug.Log("Flag A, Flag B 둘 중 하나는 True 이다");
        //}
        //else
        //{
        //    Debug.Log("조건식이 참이 아닙니다");
        //}

        // 주석 단축키 : Ctrl + K, Ctrl + C
        // 주석 해제 단축키 : Ctrl + K, Ctrl + U

        // 1 Case
        if (sampleA >= sampleB)
        {
            Debug.Log("sample A가 sampleB 보다 크거나 같다.");
        }
        else if (sampleA < sampleB)
        {
            Debug.Log("sample A가 sampleB 보다 작다.");
        }

        // 2 Case
        if (sampleA == sampleB)
        {
            Debug.Log("sample A와 sampleB는 같다.");
        }
        else
        {
            Debug.Log("sample A와 sampleB는 다르다.");
        }

        // 3 Case
        if (sampleA != sampleB)
        {
            Debug.Log("sample A와 sampleB는 다르다.");
        }
        else
        {
            Debug.Log("sample A와 sampleB는 같다.");
        }


        Debug.Log(result);
    }
}
