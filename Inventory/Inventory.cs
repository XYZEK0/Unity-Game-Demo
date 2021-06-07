using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public InventoryUI invUI;
    public List<Item> itemList;
    public static Inventory instance;

    #region Singleton

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }

        //invUI = InventoryUI.instance;
        //invUI.Init();
    }
    #endregion


    public int inventorySpace = 20;

    public bool AddItem(Item item)
    {
        if (itemList.Count < inventorySpace && CheckForDuplicates(item))
        {
            itemList.Add(item);
            
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();

            return true;
        }
        else
        {
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            return false;
        }
    }

    private bool CheckForDuplicates(Item item)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == item)
                return false;
        }
        return true;
    }

    public void RemoveItem(Item item)
    {
        if (item.Amount == 1)
            itemList.Remove(item);
        else item.Amount--;

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

    }
}
