using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleUnityCycle : MonoBehaviour
{
    void Awake()  // 1����
    {
        Debug.Log("Awake Called !!");
    }

    void OnEnable() // 2����
    {
        Debug.Log("OnEnable Called !!");
    }

    void Start() // 3����
    {
        Debug.Log("Start Called !!");
    }

    // Update : ���� ������ ó���� �� ����Ѵ�.
    void Update()
    {
        Debug.Log("Update Called !!");
    }

    // FixedUpdate : �������� ������ ó���� �� ����Ѵ�.
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate Called !!");
    }

    // LateUpdate : ī�޶� �̵��̳�/������ ������ ������ ������ �ʿ��� ��쿡 ����Ѵ�.
    void LateUpdate()
    {
        Debug.Log("LateUpdate Called !!");
    }

    // OnDisable :
    // ���� ������Ʈ�� ������ ��, ȣ�� �ȴ�.
    // �Ǵ� ������Ʈ�� �ı� �� ���� ȣ��ȴ�
    void OnDisable()
    {
        Debug.Log("OnDisable Called !!");
    }

    // OnDestroy :
    // ���ӿ�����Ʈ�� �ı� �� ��, ȣ�� �ȴ�.
    void OnDestroy()
    {
        Debug.Log("OnDestroy Called !!");
    }
}
