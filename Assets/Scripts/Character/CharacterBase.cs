using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class CharacterBase : MonoBehaviour
    {
        public float hp;

        public void TakeDamage(float damage)
        {
            hp -= damage;
        }

        public void Heal(float amount)
        {
            hp += amount;
        }
    }
}

