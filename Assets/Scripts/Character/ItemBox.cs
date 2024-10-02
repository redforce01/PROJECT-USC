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
            // 로그를 출력한다.
            Debug.Log("ItemBox Interact !!!");

            // 아이템 박스 현재 자기자신 GameObject를 파괴한다.
            Destroy(gameObject);
        }
    }
}

