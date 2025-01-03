using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Stats 
{
    [SerializeField] int baseValue;
   public List<int> modifiers;



   public int GetValue()
   {
     int value = baseValue;
     foreach(int modifier in modifiers)
     {
        value += modifier;
     }

     return value;
   }

   public void AddModifier(int _mod)
   {

        modifiers.Add(_mod);

   }
   public void RemoveModifier(int _mod)
   {

        modifiers.Remove(_mod);

   }

}
