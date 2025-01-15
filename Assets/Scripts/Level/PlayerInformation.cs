using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInformation
{
    [Header("Stat Information")]
    public string playerName;
    public Sprite characterImage;
    public int playerLevel = 1;
    [Header("Experience")]

    public int currentXP;
    public int[] expToNextLevel;
    private int maxLevel = 100;


    [Header("Status Values")]   
    public  int currentHP = 1;
    public Stats maxHP;
    public int currentMP;
    public Stats MaxMP;   
    public Stats attack;
    public Stats defense;
    public Stats magic;// intelligence
    public Stats magicDefense;
 
    public Stats speed; // speed

    [Header("Equipment")]

    public Stats weaponPower;
    public Stats armorPower;

    [Header("Sanity Meter")]
    public int friendship;

    public int sanity;

    public int maxSanity;

   

}
