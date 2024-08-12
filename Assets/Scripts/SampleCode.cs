using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCode : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello World");

        // 변수 : Variable
        // 1. 변수를 선언할 때는 항상 타입(Type)을 지정해야한다. (ex. => "int")
        // 2. 변수의 이름을 선언한다. (ex. => "a")
        // 3. 변수에 값을 대입한다. (ex. => "=") => 대입 기호 뒤에다가 값을 넣어준다.

        int a = 100;
        int b = 200;

        // 4. 변수를 사용한다. (ex. => "Debug.Log(a);" 이부분에서 "a" 라는 변수 이름을 쓴 부분
        Debug.Log(a);
        Debug.Log(b);

        // ; 세미콜론(;)은 문장의 끝을 의미한다.
        // 항상 코드 하나하나(한줄 한줄)을 마무리 지을 때는 ; 세미콜론을 붙여줘야한다.
    }
}
