using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleReadOnly
{
    public int countA = 10;
    public readonly int countB = 20;

    // 기본 생성자 
    // => 자기자신 클래스 이름과 동일한 형태의 함수처럼 생겼음
    // => 생성자는 리턴(반환형) 타입 자리가 없는 함수처럼 생겼음
    // => 별도의 생성자를 구현하지 않았다면, 아래의 기본 생성자가 생략되어있구나 라고 생각하면 편함

    //public ExampleReadOnly() 
    //{
    //}

    // 별도의 생성자를 만들어서 readonly 필드를 초기화 하는 방법
    public ExampleReadOnly(int countA, int countB)
    {
        this.countA = countA;
        this.countB = countB;
    }

    // 생성자를 여러개 만드는 것도 가능하다.
    public ExampleReadOnly(int a, int b, int c)
    {
    }
}

public class SampleReadonly : MonoBehaviour
{
    void Start()
    {
        //ExampleReadOnly exampleA = new ExampleReadOnly();
        //ExampleReadOnly exampleB = new ExampleReadOnly();

        //exampleA.countA = 99999;
        //exampleB.countA = -100;

        //// 안되는 케이스
        //exampleA.countB = 100;
        //exampleB.countB = 200;

        // 생성자를 이용해서 readonly 필드를 초기화 하는 방법
        ExampleReadOnly exampleC = new ExampleReadOnly(10, 20);
    }
}
