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
            Debug.Log("���� ����� Sword �Դϴ�");
        }
        else if (myWeaponType == /*2*/ WeaponType.Bow)
        {
            Debug.Log("���� ����� Bow �Դϴ�");
        }
        else if (myWeaponType == /*3*/ WeaponType.Staff)
        {
            Debug.Log("���� ����� Staff �Դϴ�");
        }
        else
        {
            Debug.Log("���� ���Ⱑ �������� �𸣰ڽ��ϴ�");
        }
    }
}
