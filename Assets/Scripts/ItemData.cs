using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Equipment,
    Consumable, 
    Key, // main quest
    Resource, // crafting

    Required // side quest
 

}



[CreateAssetMenu(menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Item Information")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    public GameObject itemPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

}

