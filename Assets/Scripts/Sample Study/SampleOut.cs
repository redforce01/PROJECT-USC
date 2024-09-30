using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleOut : MonoBehaviour
{
    private void Start()
    {
        int value = 100;
        ChangeValue(out value);

        // out : 기능적으로는 ref 와 비슷하지만, out 은 초기화를 하지 않고 넘겨도 된다.
        // ref : out과 동일하게, 참조의 형태로 변수를 넘기기 위하여 사용. ref는 초기화가 필요하다.
        // in : ref,out 과 동일하게 참조 형태로 변수를 넘기지만, 읽기 전용으로 넘길 때 사용한다.

        Debug.Log(value);
    }

    void ChangeValue(out int parameter)
    {
        parameter = 200;
    }
}
