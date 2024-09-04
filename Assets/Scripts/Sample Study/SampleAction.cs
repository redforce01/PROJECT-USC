using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAction : MonoBehaviour
{
    // To do :
    // 1. Update���� Input.GetKeyDown ���� 1,2,3��Ű�� ������ ?
    // 2.  => 1,2,3�� Ű�� ������ ��, �����ϴ� "�׼� �̺�Ʈ"�� ������ (�׼� �̺�Ʈ�� 3���� �ʿ���)
    // 3.   => �� �׼� �̺�Ʈ�� ����(:Chain)�� �ٸ� �ܺ� Ŭ�������� �� �׼��� �ҷ����ٶ�� �̺�Ʈ�� �ߵ��ƴ��� Ȯ��

    // �ݹ� �Լ��� ������ ����
    //public delegate void ActionEvent();

    //public ActionEvent actionCallback_1;
    //public ActionEvent actionCallback_2;
    //public ActionEvent actionCallback_3;

    // System.Action �� ����ϸ� delegate �� ���� �ȸ���, �ݹ� �Լ��� ������ ���� �ִ�.
    // �ٸ�, System.Action�� ��ȯ���� void �̾�� �Ѵ�. (:���� ����)
    public System.Action actionCallback_1;
    public System.Action actionCallback_2;
    public System.Action actionCallback_3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            actionCallback_1();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            actionCallback_2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            actionCallback_3();
        }
    }
}
