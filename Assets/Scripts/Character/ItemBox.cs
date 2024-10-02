using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class ItemBox : MonoBehaviour, IInteractable
    {
        public string InteractionMessage => itemName;

        public string itemName;

        public void Interact()
        {
            // �α׸� ����Ѵ�.
            Debug.Log("ItemBox Interact !!!");

            // ������ �ڽ� ���� �ڱ��ڽ� GameObject�� �ı��Ѵ�.
            Destroy(gameObject);
        }
    }
}

