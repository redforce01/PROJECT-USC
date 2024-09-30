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

            // ���� ü���� �����, ü�� ���� 0���� �۰ų� ���ٸ�? ����� ���ӿ�����Ʈ�� ��������.
            if (currentHP <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

