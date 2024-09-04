using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleOverride_ChildA : SampleOverride_Base
{
    public override void Attack()
    {
        Debug.Log("Child A Action Attack !!!");
    }
}
