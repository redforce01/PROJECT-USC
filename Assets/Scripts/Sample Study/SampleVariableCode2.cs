using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleVariableCode2 : MonoBehaviour
{
    int sampleA = 10;  // sampleA : 멤버변수(Field:필드)
    int sampleB = 20;  // sampleB : 멤버변수(Field:필드)

    void Start() // 파랗게 칠해져 있는 Keyword 들을 => "예약어" 라고 부른다.
    {
        int localA = 30; // localA : 지역변수 Local Variable
        int localB = 40; // localB : 지역변수 Local Variable

        Sum(sampleA, sampleB);
        Sum(localA, localB);

        int result = MyFunction(10, 5); // 10 + 5를 수행한 결과 값이 result에 저장된다.
        Debug.Log(result); // 15가 출력된다.
    }

    int MyFunction(int x, int y)
    {
        return x + y;
    }

    // 함수의 형태 : 접근한정자 | 반환형(Return Type) | 함수 이름(Method Name) | 매개변수(Parameter)
    // 접근 한정자 : public, private, protected, internal
    // 반환형 : int, bool, float...(데이터 타입)
    // 함수 이름 : 프로그래머가 지정하는 고유한 네이밍
    // 매개변수 : 함수를 호출할때 전달하는 데이터들의 자리
    void Sum(int a, int b)
    {
        int result = a + b;
        Debug.Log(result);
    }
}
