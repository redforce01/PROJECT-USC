using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleOperator : MonoBehaviour
{
    public int sampleA = 0;
    public int sampleB = 0;
    public int result = 0;

    public bool flagA = true;
    public bool flagB = false;

    void Start()
    {
        // result = sampleA / sampleB; // +, -, *, /, %
        // result += sampleA; // result = result * sampleA; // =, +=, -=, *=, /=, %=
        // result++; result--; // ++, --

        //if (flagA && !flagB) // && : and (�׸���), || : or (�Ǵ�), ! : not (�ƴϴ�)
        //{
        //    Debug.Log("Flag A, Flag B �� �� �ϳ��� True �̴�");
        //}
        //else
        //{
        //    Debug.Log("���ǽ��� ���� �ƴմϴ�");
        //}

        // �ּ� ����Ű : Ctrl + K, Ctrl + C
        // �ּ� ���� ����Ű : Ctrl + K, Ctrl + U

        // 1 Case
        if (sampleA >= sampleB)
        {
            Debug.Log("sample A�� sampleB ���� ũ�ų� ����.");
        }
        else if (sampleA < sampleB)
        {
            Debug.Log("sample A�� sampleB ���� �۴�.");
        }

        // 2 Case
        if (sampleA == sampleB)
        {
            Debug.Log("sample A�� sampleB�� ����.");
        }
        else
        {
            Debug.Log("sample A�� sampleB�� �ٸ���.");
        }

        // 3 Case
        if (sampleA != sampleB)
        {
            Debug.Log("sample A�� sampleB�� �ٸ���.");
        }
        else
        {
            Debug.Log("sample A�� sampleB�� ����.");
        }


        Debug.Log(result);
    }
}
