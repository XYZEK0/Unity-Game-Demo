using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Item : ScriptableObject
{
    new public string name = null;

    public string description = null;

    public int itemID;

    public Sprite icon = null;

    public bool isStackable;

    [System.NonSerialized] private int amount;


    public int Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }

    }
    public enum ItemType
    {
        Food,
        Ingredient,
        Utility,
        None
    }


    public ItemType itemType;

    public virtual void Use()
    {
        Debug.Log($"I have used an {name} ");
    }


    
}


