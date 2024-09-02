using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SampleCharacterBase
{
    public delegate void DamagedCallback(string name, float damage, float remainHP);
    public event DamagedCallback OnDamaged;

    public float hp;
    public string name;

    public void ApplyDamage(float damage)
    {
        hp -= damage;
        OnDamaged(name, damage, hp);
    }
}

public class SampleEvent : MonoBehaviour
{
    public SampleCharacterBase characterA;
    public SampleCharacterBase characterB;

    private void Start()
    {
        characterA = new SampleCharacterBase();
        characterB = new SampleCharacterBase();

        characterA.name = "Character A";
        characterA.hp = 100;

        characterB.name = "Character B";
        characterB.hp = 300;

        characterA.OnDamaged += OnCharacterDamaged;
        
        // OnDamaged 에 "event" 라는 키워드가 걸려있기 때문에,
        // 외부 클래스 입장에서는 OnDamaged에 직접 초기화를 진행할 수 없다.
        // Error => characterA.OnDamaged = null;

        characterB.OnDamaged += OnCharacterDamaged;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            characterA.ApplyDamage(10f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterB.ApplyDamage(10f);
        }
    }

    public void OnCharacterDamaged(string name, float damage, float remainHP)
    {
        Debug.LogFormat("Character:{0}, Damage: {1}, Remain HP: {2}", name, damage, remainHP);
    }
}
