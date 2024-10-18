using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSwitch : MonoBehaviour
{
    public enum SampleSwitchType
    {
        None,
        SwitchA,
        SwitchB,
        SwitchC,

        Unknown_1,
        Unknown_2,
        Unknown_3,
    }

    public SampleSwitchType switchMode;

    void Start()
    {
        switch (switchMode)
        {
            case SampleSwitchType.None:
                Debug.Log("Switch Mode is None");
                break;
            case SampleSwitchType.SwitchA:                                
            case SampleSwitchType.SwitchB:
                Debug.Log("Switch Mode is B");
                break;
            case SampleSwitchType.SwitchC:
                Debug.Log("Switch Mode is C");
                break;
            default:
                Debug.Log("Switch Mode is Unknown");
                break;
        }

        if (switchMode == SampleSwitchType.None)
        {
            Debug.Log("Switch Mode is None");
        }
        else if (switchMode == SampleSwitchType.SwitchB || switchMode == SampleSwitchType.SwitchA)
        {
            Debug.Log("Switch Mode is B");
        }
        else if (switchMode == SampleSwitchType.SwitchC)
        {
            Debug.Log("Switch Mode is C");
        }
        else
        {
            Debug.Log("Switch Mode is Unknown");
        }
    }
}
