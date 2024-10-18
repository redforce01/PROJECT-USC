using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleIf : MonoBehaviour
{
    public int sampleA = 0;
    public int sampleB = 100;

    void Update()
    {
        // ���ǹ�
        // C# : ���ǹ� - if / switch (���� ��/ ����ġ ��)
        // ���� : if (���ǽ�) { ���� ����(����:Logic) }
        if (sampleA > sampleB)
        {
            Debug.Log("Sample A �� B ���� ũ��.");
        }
        else if (sampleA == sampleB)
        {
            Debug.Log("Sample A �� B �� ����.");
        }
        else
        {
            Debug.Log("Sample A �� B ���� �۴�.");
        }
    }
}
