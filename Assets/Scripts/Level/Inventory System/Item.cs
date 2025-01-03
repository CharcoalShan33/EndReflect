using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    public ItemData data;
    public int stackAmount;


    public Item(ItemData _newData)
    {
        data = _newData;
        AddStack();
    }

    public void AddStack() => stackAmount++;
    public void RemoveStack() => stackAmount--;

}
