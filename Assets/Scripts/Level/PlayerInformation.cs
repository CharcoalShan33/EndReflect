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
    public int maxHP;
    public int currentMP;
    public int MaxMP;   
    public int attack;
    public int defense;
    public int magic;// intelligence
    public int magicDefense;
 
    public int speed; // speed

    [Header("Equipment")]

    public int weaponPower;
    public int armorPower;

    [Header("Sanity Meter")]
    public int friendship;

    public int sanity;

    public int maxSanity;
}
