using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleArray : MonoBehaviour
{
    // Array : 배열
    // 1. 배열은 항상 0 번째부터 순서를 체크한다.
    // 2. 배열은 항상 같은 타입(데이터타입)으로 묶여있어야한다.
    // 3. 배열에 들어있는 값을 접근할 때는 [ ] (대괄호 기호 안에) 인덱스 값을 넣는다.
    public string[] equipmentNames;

    private void Start()
    {
        Debug.Log("Before");
        Debug.Log("장착중인 장비 1 번째: " + equipmentNames[0]);
        Debug.Log("장착중인 장비 2 번째: " + equipmentNames[1]);
        Debug.Log("장착중인 장비 3 번째: " + equipmentNames[2]);
        Debug.Log("장착중인 장비 4 번째: " + equipmentNames[3]);

        Debug.Log("After");
        equipmentNames[0] = "무인검";
        equipmentNames[1] = "썩은칼";

        Debug.Log("장착중인 장비 1 번째: " + equipmentNames[0]);
        Debug.Log("장착중인 장비 2 번째: " + equipmentNames[1]);
        Debug.Log("장착중인 장비 3 번째: " + equipmentNames[2]);
        Debug.Log("장착중인 장비 4 번째: " + equipmentNames[3]);

        //for (int i = 0; i < equipmentNames.Length; i++)
        //{
        //    Debug.Log("장착중인 장비: " + equipmentNames[i]);
        //}
    }
}
