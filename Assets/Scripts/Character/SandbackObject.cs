using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class SandbackObject : MonoBehaviour, IDamage
    {
        public float currentHP;
        public float maxHP;

        public SandbackVisualData[] visualDatas;

        public void ApplyDamage(float damage)
        {
            currentHP -= damage;

            Renderer selfRenderer = GetComponent<Renderer>();
            if (selfRenderer != null)
            {
                int visualDataIndex = 0;
                float currentHpRatio = currentHP / maxHP;
                for (int i = 0; i < visualDatas.Length; i++)
                {
                    if (currentHpRatio >= visualDatas[i].rangeMin && currentHpRatio < visualDatas[i].rangeMax)
                    {
                        visualDataIndex = i;
                    }
                }
                selfRenderer.material.color = visualDatas[visualDataIndex].color;
            }

            // 만약 체력을 깍고나서, 체력 값이 0보다 작거나 같다면? 샌드백 게임오브젝트를 꺼버린다.
            if (currentHP <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

