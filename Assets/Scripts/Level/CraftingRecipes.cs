using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Crafting" , menuName = "Crafting Recipes")]
public class CraftingRecipes : ScriptableObject
{
    public ItemData itemToCraft;
    public Costs[] allCosts;

}

[System.Serializable]
public class Costs 
{
 public int quantity;

public ItemData item;
}


