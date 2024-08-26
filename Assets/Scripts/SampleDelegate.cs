using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDelegate : MonoBehaviour
{    
    // ��������Ʈ(:delegate) : � �ݹ�(:Callback) �Լ��� ���¸� "����" �ϴ� ��  
    public delegate void DamageCallback(float damage);

    public DamageCallback OnDamaged;

    public float hp;
    public float damage;

    private void Start()
    {
        hp = 100;
        damage = 5;

        // �̺�Ʈ�� �ݹ� �Լ��� ����ϴ� ��
        // "+=" �����ڸ� �̿��ؼ� ����(:Subscribe,Chain�� �Ǵ�)
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

        // �̺�Ʈ�� �߻�(:ȣ��)��Ų��.
        OnDamaged(damage);
    }


    public void DamageCallbackFunction(float damage)
    {
        Debug.Log("Taken Damage : " + damage);
    }

    public void NotifiedOnDamageAfter(float damage)
    {
        Debug.Log("�� ������ �޾ҵ�!! �������� 50���� ū��? ũ��Ƽ�� �������ΰ�?");
        if (damage > 50f)
        {
            Debug.Log("ũ��Ƽ�� ��������!");
        }
        else
        {
            Debug.Log("�Ϲ����� �������� �޾ұ�");
        }
    }
}
