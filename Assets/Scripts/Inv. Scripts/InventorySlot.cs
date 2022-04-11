using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item _item;
    public Image icon;

    public void AddItem(Item i)
    {
        _item = i;
        icon.sprite = i.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        _item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
