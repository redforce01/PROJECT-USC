using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCode : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello World");

        // ���� : Variable
        // 1. ������ ������ ���� �׻� Ÿ��(Type)�� �����ؾ��Ѵ�. (ex. => "int")
        // 2. ������ �̸��� �����Ѵ�. (ex. => "a")
        // 3. ������ ���� �����Ѵ�. (ex. => "=") => ���� ��ȣ �ڿ��ٰ� ���� �־��ش�.

        int a = 100;
        int b = 200;

        // 4. ������ ����Ѵ�. (ex. => "Debug.Log(a);" �̺κп��� "a" ��� ���� �̸��� �� �κ�
        Debug.Log(a);
        Debug.Log(b);

        // ; �����ݷ�(;)�� ������ ���� �ǹ��Ѵ�.
        // �׻� �ڵ� �ϳ��ϳ�(���� ����)�� ������ ���� ���� ; �����ݷ��� �ٿ�����Ѵ�.
    }
}
