using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class InteractionUI_ListItem : MonoBehaviour
    {
        public string InteractionText
        {
            set
            {
                itemNameText.text = value;
            }
        }

        public bool IsShowShortcut
        {
            set
            {
                shortcut.SetActive(value);
            }
        }

        public IInteractable InteractionData { get; set; }

        public void Execute()
        {
            InteractionData?.Interact();
        }

        public TMPro.TextMeshProUGUI itemNameText;
        public GameObject shortcut;
    }
}

