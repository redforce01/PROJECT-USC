using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class DamageMultiflier : MonoBehaviour
    {
        // [] : ���� �κ��� Attribute ��� �θ�
        // ���� �� �ڿ� get; set; �ϰ� �����͵��� Property ��� �θ�
        // get; set;�� ���ٸ� �Ϲ� ��� ����[:field] ��� �θ�

        [field: SerializeField] public float DamageMultiplier { get; set; } = 1.0f;
    }
}
