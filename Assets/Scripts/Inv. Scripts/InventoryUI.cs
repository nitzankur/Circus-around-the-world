using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    public Transform itemParent;
    private InventorySlot[] _slots;

    void Start()
    {
        _inventory = Inventory.UserInventory;
        _inventory.OnItemChangedCallback += UpdateUI;
        _slots = itemParent.GetComponentsInChildren<InventorySlot>();
    }
    
    private void UpdateUI()
    {
        for (var i = 0; i < _slots.Length; i++)
        {
            if(i < _inventory.items.Count) _slots[i].AddItem(_inventory.items[i]);
            else _slots[i].ClearSlot();
            
        }
        
    }
}
