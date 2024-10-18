using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleUnityCycle : MonoBehaviour
{
    void Awake()  // 1순위
    {
        Debug.Log("Awake Called !!");
    }

    void OnEnable() // 2순위
    {
        Debug.Log("OnEnable Called !!");
    }

    void Start() // 3순위
    {
        Debug.Log("Start Called !!");
    }

    // Update : 게임 로직을 처리할 때 사용한다.
    void Update()
    {
        Debug.Log("Update Called !!");
    }

    // FixedUpdate : 물리적인 연산을 처리할 때 사용한다.
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate Called !!");
    }

    // LateUpdate : 카메라 이동이나/마지막 렌더링 직전에 연산이 필요한 경우에 사용한다.
    void LateUpdate()
    {
        Debug.Log("LateUpdate Called !!");
    }

    // OnDisable :
    // 게임 오브젝트가 꺼졌을 때, 호출 된다.
    // 또는 오브젝트가 파괴 될 때도 호출된다
    void OnDisable()
    {
        Debug.Log("OnDisable Called !!");
    }

    // OnDestroy :
    // 게임오브젝트가 파괴 될 때, 호출 된다.
    void OnDestroy()
    {
        Debug.Log("OnDestroy Called !!");
    }
}
