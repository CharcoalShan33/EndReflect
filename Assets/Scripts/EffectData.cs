using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EffectData 
{
     public string spellName;
    public int power;
    public int mpCost;

    public enum SpellType { Attack, Healing, Buff, Debuff }
    public SpellType currentSpellType;

    public GameObject SpellVFX;

   


}
