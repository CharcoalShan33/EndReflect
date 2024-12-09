using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
   public string spellName;
   public int power;
   public int mpCost;

   public enum SpellType { Attack, Healing, Buff, Debuff}
    public SpellType currentSpellType;

    private Vector3 targetPosition;

    private  void Update()
    {
        
    }



}
