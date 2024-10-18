using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDelegate : MonoBehaviour
{    
    // 델리게이트(:delegate) : 어떤 콜백(:Callback) 함수의 형태를 "정의" 하는 것  
    public delegate void DamageCallback(float damage);

    public DamageCallback OnDamaged;

    public float hp;
    public float damage;

    private void Start()
    {
        hp = 100;
        damage = 5;

        // 이벤트에 콜백 함수를 등록하는 것
        // "+=" 연산자를 이용해서 구독(:Subscribe,Chain을 건다)
        OnDamaged += DamageCallbackFunction;
        OnDamaged += NotifiedOnDamageAfter;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyDamage(damage);
        }
    }

    public void ApplyDamage(float damage)
    {
        hp -= damage;

        // 이벤트를 발생(:호출)시킨다.
        OnDamaged(damage);
    }


    public void DamageCallbackFunction(float damage)
    {
        Debug.Log("Taken Damage : " + damage);
    }

    public void NotifiedOnDamageAfter(float damage)
    {
        Debug.Log("나 데미지 받았따!! 데미지가 50보다 큰가? 크리티컬 데미지인가?");
        if (damage > 50f)
        {
            Debug.Log("크리티컬 데미지다!");
        }
        else
        {
            Debug.Log("일반적인 데미지를 받았군");
        }
    }
}
