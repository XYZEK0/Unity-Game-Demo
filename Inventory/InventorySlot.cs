using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Button removeButton;
    public Image icon;
    public TextMeshProUGUI text;
    
    private void Awake()
    {
        text.enabled = false;
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
       // removeButton.interactable = true;
        icon.sprite = item.icon;
        icon.enabled = true;
        text.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        //removeButton.interactable = false;
        icon.sprite = null;
        icon.enabled = false;
        text.enabled = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.RemoveItem(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
    public void ChangeText(Item item)
    {
        text.text = item.Amount.ToString();
    }
}
