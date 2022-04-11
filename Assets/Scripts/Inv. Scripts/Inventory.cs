using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singelton
    public static Inventory UserInventory;
    private void Awake()
    {
        if (UserInventory != null) return;
        UserInventory = this;
    }
    #endregion

    private int _space = 8;
    
    public delegate void OnItemChanged();

    public OnItemChanged OnItemChangedCallback;
    
    public List<Item> items = new List<Item>();

    public bool Add(Item i)
    {
        if(items.Count >= _space) return false;
        items.Add(i);
        OnItemChangedCallback?.Invoke();
        return true;
    }

    public void Remove(Item i)
    {
        items.Remove(i);
        OnItemChangedCallback?.Invoke();
    }
}