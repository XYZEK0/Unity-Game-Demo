using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemPickup : Interactible
{
    public Item item = null;
    public DontSpawn dontSpawn;
    
    public override void Interact()
    {
        base.Interact();
        Debug.Log(item.Amount);
        PickUP();
    }

    private bool CheckIfStackable()
    {
        if (item.isStackable) return true;

        gameObject.SetActive(false);
        return false;
    }

    private void PickUP()
    {
        bool itemWasAdded =  Inventory.instance.AddItem(item); //Zwraca true jeżeli item został dodany nowy przedmiot

        if (itemWasAdded)
        {
            Debug.Log($"Picked up {item.name}");
            if (CheckIfStackable())
            { 
                item.Amount++; 
            }
            else
            {
                item.Amount = 1;
            }
            Inventory.instance.onItemChangedCallback.Invoke();
            Debug.Log(item.Amount);
        }
        else if (CheckIfStackable())
        {    
            //Stack items 
            item.Amount++;
            Inventory.instance.onItemChangedCallback.Invoke();
            Debug.Log(item.Amount);
        }
        else
        {
            Inventory.instance.itemList.Add(item);
            Inventory.instance.onItemChangedCallback.Invoke();
        }

        //Destroy(gameObject);
        dontSpawn.wasPickedUp = true;
        gameObject.SetActive(false);
    }
}
