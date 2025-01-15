using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Consumable")]


public class ConsumableData : ItemData
{
    public enum ItemEffect
{
    Healing, // for mp and hp, stamina
    Increasing, // upgrading stats

    Revive
}
public ItemEffect effect;

public int recoverAmount;
public int statGainAmount;



}
