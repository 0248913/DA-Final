using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image Icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        Icon.sprite = item.icon;
        Icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        Icon.sprite = null;
        Icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
