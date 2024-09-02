using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnum : MonoBehaviour
{
    public enum WeaponType
    {
        None = 0,
        Sword = 1,
        Bow = 2,
        Staff = 3,
    }

    public WeaponType myWeaponType;
    //public int myWeaponType;

    private void Start()
    {
        if (myWeaponType == /*1*/ WeaponType.Sword)
        {
            Debug.Log("현재 무기는 Sword 입니다");
        }
        else if (myWeaponType == /*2*/ WeaponType.Bow)
        {
            Debug.Log("현재 무기는 Bow 입니다");
        }
        else if (myWeaponType == /*3*/ WeaponType.Staff)
        {
            Debug.Log("현재 무기는 Staff 입니다");
        }
        else
        {
            Debug.Log("현재 무기가 무엇인지 모르겠습니다");
        }
    }
}
