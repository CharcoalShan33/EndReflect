using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Stats", menuName = "Stats/Hero")]
public class CharacterStats: MonoBehaviour
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

    public int Attack;
    public int Defense;
    public Stats defense;
    public Stats magic;// intelligence
    public Stats magicDefense;
 
    public Stats speed; // speed

    [Header("Others")]
    public bool isPlayer;
    public bool isDead;

    [Header("Equipment")]

    public Stats weaponPower;
    public Stats armorPower;

    [Header("Sanity Meter")]
    public int friendship;

    public int sanity;

    public int maxSanity;

    void Start()
    {
        

    SetValues();
   

        
    }

    public void SetValues()
    {
        currentHP = maxHP.GetValue();
        currentMP = MaxMP.GetValue();
        attack.GetValue();
        defense.GetValue();
        magic.GetValue();
        magicDefense.GetValue();
        speed.GetValue();
        weaponPower.GetValue();
        armorPower.GetValue();



    }
}
