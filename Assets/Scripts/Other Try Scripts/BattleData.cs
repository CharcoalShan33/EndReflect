using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

[System.Serializable]
public class BattleData 
{
     [SerializeField] bool isPlayer;
    [SerializeField] string[] allAttacks;

    [SerializeField] bool isFlipped;

   [SerializeField]string characterName;
    [SerializeField] int currentHP, maxHP, currentMana, maxMana, attack, magic, dexterity, defense, battleLevel, speed;
   [SerializeField] bool isDead;
    [SerializeField]SpriteRenderer spr;

    [SerializeField] Animator _anim;

    public void SetSpeedValue(int fast)
    {
        speed = fast;
       
    }

    public void SetOtherFields(string name, int currentHealth, int maxHealth, 
    int currentMP, int maxMP, int intelligence, int endurance, 
    int strength, int deft, int level, bool player)
    {
        characterName = name;
    currentHP = currentHealth;
     maxHP = maxHealth;
     currentMana = currentMP;
      maxMana = maxMP;
      attack = strength;
      magic = intelligence;
      dexterity = deft;
      defense = endurance;
      battleLevel = level;
      isPlayer = player;
    }
}
