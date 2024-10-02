using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class InteractionUI : MonoBehaviour
    {
        public Transform group;
        public InteractionUI_ListItem itemPrefab;

        private List<InteractionUI_ListItem> createdListItems = new List<InteractionUI_ListItem>();
        private int selectedIndex = -1;

        public void Execute()
        {
            if(selectedIndex >= 0 && selectedIndex < createdListItems.Count)
            {
                createdListItems[selectedIndex].Execute();
            }
        }

        public void ClearList()
        {
            for(int i = 0; i < createdListItems.Count; i++)
            {
                Destroy(createdListItems[i].gameObject);
            }

            createdListItems.Clear();
        }

        public void SetInteractableObjects(IInteractable[] interactions)
        {
            ClearList();
            for (int i = 0; i < interactions.Length; i++)
            {
                InteractionUI_ListItem newListItem = Instantiate(itemPrefab, group);
                newListItem.IsShowShortcut = false;
                newListItem.InteractionText = interactions[i].InteractionMessage;
                newListItem.InteractionData = interactions[i];

                createdListItems.Add(newListItem);
            }
        }
    }
}
