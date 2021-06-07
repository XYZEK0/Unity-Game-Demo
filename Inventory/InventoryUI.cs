using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region Singleton

    public static InventoryUI instance;

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
    }
    #endregion

    public Transform itemsParent;
    public GameObject inventoryUI;
    InventorySlot[] slots;
    Inventory inventory;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }
    private void Update()
    {
        //UpdateUI();
        if (Input.GetKeyDown(KeyCode.I))
        {
            CloseInventory();
        }
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        Debug.Log("Updating UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.itemList.Count)
                slots[i].ChangeText(inventory.itemList[i]);
        }
    }
}