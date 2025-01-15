using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Stats 
{
    [SerializeField] int baseValue;
   public List<int> modifiers;


   public int GetValue()
   {
    int finalValue = baseValue;
    foreach (int modify in modifiers)
    {
      finalValue += modify;
    }
    return finalValue ;
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
