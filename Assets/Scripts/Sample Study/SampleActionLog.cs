using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleActionLog : MonoBehaviour
{
    public SampleAction sampleAction;

    private void Awake()
    {
        sampleAction = GetComponent<SampleAction>();

        sampleAction.actionCallback_1 += ActionA;
        sampleAction.actionCallback_2 += ActionB;
        sampleAction.actionCallback_3 += ActionC;
    }

    private void ActionA()
    {
        Debug.Log("Action A");
    }

    private void ActionB()
    {
        Debug.Log("Action B");
    }

    private void ActionC()
    {
        Debug.Log("Action C");
    }
}
