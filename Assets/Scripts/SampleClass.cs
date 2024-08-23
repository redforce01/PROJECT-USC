using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SampleDataStruct
{
    public int sampleValue;

    public void SampleFunction()
    {
        Debug.Log(sampleValue);
    }
}

[System.Serializable]
public class SampleDataClass
{
    public int sampleValue;

    public void SampleFunction()
    {
        Debug.Log(sampleValue);
    }
}

public class SampleClass : MonoBehaviour
{
    public SampleDataClass sampleA;
    public SampleDataClass sampleB;

    public SampleDataStruct sampleC;
    public SampleDataStruct sampleD;

    void Start()
    {
        sampleA.sampleValue = 99999;
        sampleB.sampleValue = 12345;
        sampleA.SampleFunction();
        sampleB.SampleFunction();

        sampleC.sampleValue = 500;
        sampleD.sampleValue = 1000;
        sampleC.SampleFunction();
        sampleD.SampleFunction();
    }
}
