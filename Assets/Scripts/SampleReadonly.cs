using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleReadOnly
{
    public int countA = 10;
    public readonly int countB = 20;

    // �⺻ ������ 
    // => �ڱ��ڽ� Ŭ���� �̸��� ������ ������ �Լ�ó�� ������
    // => �����ڴ� ����(��ȯ��) Ÿ�� �ڸ��� ���� �Լ�ó�� ������
    // => ������ �����ڸ� �������� �ʾҴٸ�, �Ʒ��� �⺻ �����ڰ� �����Ǿ��ֱ��� ��� �����ϸ� ����

    //public ExampleReadOnly() 
    //{
    //}

    // ������ �����ڸ� ���� readonly �ʵ带 �ʱ�ȭ �ϴ� ���
    public ExampleReadOnly(int countA, int countB)
    {
        this.countA = countA;
        this.countB = countB;
    }

    // �����ڸ� ������ ����� �͵� �����ϴ�.
    public ExampleReadOnly(int a, int b, int c)
    {
    }
}

public class SampleReadonly : MonoBehaviour
{
    void Start()
    {
        //ExampleReadOnly exampleA = new ExampleReadOnly();
        //ExampleReadOnly exampleB = new ExampleReadOnly();

        //exampleA.countA = 99999;
        //exampleB.countA = -100;

        //// �ȵǴ� ���̽�
        //exampleA.countB = 100;
        //exampleB.countB = 200;

        // �����ڸ� �̿��ؼ� readonly �ʵ带 �ʱ�ȭ �ϴ� ���
        ExampleReadOnly exampleC = new ExampleReadOnly(10, 20);
    }
}
