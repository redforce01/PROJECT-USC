using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleVariableCode : MonoBehaviour
{
    void Start()
    {
        // 변수 : 데이터를 의미한다.
        // DataType | Name | Value
        // DataType : bool,int,float,string
        // Name : 변수 이름(프로그래머가 지정하는 네이밍)
        // "=" : 수학에서는 같다 라는 의미? 프로그래밍에서는 "대입" 이라는 의미
        // "==" : 프로그래밍에서는 "같다" 라는 의미는 "=" 기호를 2번 사용한다.
        // Value : 변수에 저장되는 값

        bool sampleBool = false;
        int sampleValue = 10234234;
        float sampleFloat = 33.312f;
        double sampleDouble = 33.123;
        string sampleString = "Hello World!";
        char sampleChar = 'a';

        Debug.Log(sampleBool);
        Debug.Log(sampleValue);
        Debug.Log(sampleFloat);
        Debug.Log(sampleString);
    }
}
