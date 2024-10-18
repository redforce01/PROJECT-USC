using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleIf : MonoBehaviour
{
    public int sampleA = 0;
    public int sampleB = 100;

    void Update()
    {
        // 조건문
        // C# : 조건문 - if / switch (이프 문/ 스위치 문)
        // 형태 : if (조건식) { 실행 내용(로직:Logic) }
        if (sampleA > sampleB)
        {
            Debug.Log("Sample A 가 B 보다 크다.");
        }
        else if (sampleA == sampleB)
        {
            Debug.Log("Sample A 와 B 가 같다.");
        }
        else
        {
            Debug.Log("Sample A 가 B 보다 작다.");
        }
    }
}
