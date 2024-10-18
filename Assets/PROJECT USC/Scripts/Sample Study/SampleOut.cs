using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleOut : MonoBehaviour
{
    private void Start()
    {
        int value = 100;
        ChangeValue(out value);

        // out : ��������δ� ref �� ���������, out �� �ʱ�ȭ�� ���� �ʰ� �Ѱܵ� �ȴ�.
        // ref : out�� �����ϰ�, ������ ���·� ������ �ѱ�� ���Ͽ� ���. ref�� �ʱ�ȭ�� �ʿ��ϴ�.
        // in : ref,out �� �����ϰ� ���� ���·� ������ �ѱ�����, �б� �������� �ѱ� �� ����Ѵ�.

        Debug.Log(value);
    }

    void ChangeValue(out int parameter)
    {
        parameter = 200;
    }
}
