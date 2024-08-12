using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleVariableCode2 : MonoBehaviour
{
    int sampleA = 10;  // sampleA : �������(Field:�ʵ�)
    int sampleB = 20;  // sampleB : �������(Field:�ʵ�)

    void Start() // �Ķ��� ĥ���� �ִ� Keyword ���� => "�����" ��� �θ���.
    {
        int localA = 30; // localA : �������� Local Variable
        int localB = 40; // localB : �������� Local Variable

        Sum(sampleA, sampleB);
        Sum(localA, localB);

        int result = MyFunction(10, 5); // 10 + 5�� ������ ��� ���� result�� ����ȴ�.
        Debug.Log(result); // 15�� ��µȴ�.
    }

    int MyFunction(int x, int y)
    {
        return x + y;
    }

    // �Լ��� ���� : ���������� | ��ȯ��(Return Type) | �Լ� �̸�(Method Name) | �Ű�����(Parameter)
    // ���� ������ : public, private, protected, internal
    // ��ȯ�� : int, bool, float...(������ Ÿ��)
    // �Լ� �̸� : ���α׷��Ӱ� �����ϴ� ������ ���̹�
    // �Ű����� : �Լ��� ȣ���Ҷ� �����ϴ� �����͵��� �ڸ�
    void Sum(int a, int b)
    {
        int result = a + b;
        Debug.Log(result);
    }
}
