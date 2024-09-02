using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class HealGimmick : MonoBehaviour
    {
        public float healAmount;
        public float healDelay;

        private CharacterBase player;
        private float lastHealTime;

        private void Update()
        {
            if (player != null)
            {
                if (Time.time > lastHealTime + healDelay)
                {
                    player.Heal(healAmount);
                    lastHealTime = Time.time;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.CompareTag("Player"))
            {
                player = other.transform.root.GetComponent<CharacterBase>();
                player.Heal(healAmount);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.root.CompareTag("Player"))
            {
                player = null;
            }
        }
    }
}

