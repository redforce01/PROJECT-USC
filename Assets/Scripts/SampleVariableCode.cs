using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleVariableCode : MonoBehaviour
{
    void Start()
    {
        // ���� : �����͸� �ǹ��Ѵ�.
        // DataType | Name | Value
        // DataType : bool,int,float,string
        // Name : ���� �̸�(���α׷��Ӱ� �����ϴ� ���̹�)
        // "=" : ���п����� ���� ��� �ǹ�? ���α׷��ֿ����� "����" �̶�� �ǹ�
        // "==" : ���α׷��ֿ����� "����" ��� �ǹ̴� "=" ��ȣ�� 2�� ����Ѵ�.
        // Value : ������ ����Ǵ� ��

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
