using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleArray : MonoBehaviour
{
    // Array : �迭
    // 1. �迭�� �׻� 0 ��°���� ������ üũ�Ѵ�.
    // 2. �迭�� �׻� ���� Ÿ��(������Ÿ��)���� �����־���Ѵ�.
    // 3. �迭�� ����ִ� ���� ������ ���� [ ] (���ȣ ��ȣ �ȿ�) �ε��� ���� �ִ´�.
    public string[] equipmentNames;

    private void Start()
    {
        Debug.Log("Before");
        Debug.Log("�������� ��� 1 ��°: " + equipmentNames[0]);
        Debug.Log("�������� ��� 2 ��°: " + equipmentNames[1]);
        Debug.Log("�������� ��� 3 ��°: " + equipmentNames[2]);
        Debug.Log("�������� ��� 4 ��°: " + equipmentNames[3]);

        Debug.Log("After");
        equipmentNames[0] = "���ΰ�";
        equipmentNames[1] = "����Į";

        Debug.Log("�������� ��� 1 ��°: " + equipmentNames[0]);
        Debug.Log("�������� ��� 2 ��°: " + equipmentNames[1]);
        Debug.Log("�������� ��� 3 ��°: " + equipmentNames[2]);
        Debug.Log("�������� ��� 4 ��°: " + equipmentNames[3]);

        //for (int i = 0; i < equipmentNames.Length; i++)
        //{
        //    Debug.Log("�������� ���: " + equipmentNames[i]);
        //}
    }
}
