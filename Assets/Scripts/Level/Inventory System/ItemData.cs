using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Equipment,
    Consumable, 
    Key, // main quest
    Resource, // crafting

}



[CreateAssetMenu(fileName ="New Item Data", menuName ="Data/Item")]
public class ItemData : ScriptableObject
{
    [Header("Item Information")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    //public GameObject itemPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

}

