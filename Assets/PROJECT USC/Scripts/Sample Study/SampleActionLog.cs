using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleActionLog : MonoBehaviour
{
    public SampleAction sampleAction;

    public int Count => count;
    //public int Count
    //{
    //    get { return count; }
    //}

    private int count;

    private void Awake()
    {
        sampleAction = GetComponent<SampleAction>();

        sampleAction.actionCallback_1 += ActionA;
        sampleAction.actionCallback_2 += ActionB;
        sampleAction.actionCallback_3 += ActionC;

        // sampleAction.actionCallback_3 += ActionLambda;
        sampleAction.actionCallback_3 += () => { Debug.Log("Lambda Action"); };
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

    private void ActionLambda()
    {
        Debug.Log("Lambda Action");
    }
}
