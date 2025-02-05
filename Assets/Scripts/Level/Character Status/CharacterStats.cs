using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public int baseXP =100;


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

    expToNextLevel = new int[maxLevel];
   
    expToNextLevel[1] = baseXP;

    for(int i = 2; i< expToNextLevel.Length; i++)
    {
        expToNextLevel[i]  = (int)(0.04 * (i ^ 3) + 0.8 * (i ^ 2) + 2 * i);
    }
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            AddExp(100);
        }
    }

    public void SetValues()
    {
        attack.SetDefaultValue(70);
        defense.SetDefaultValue(55);
        maxHP.SetDefaultValue(450);
        currentHP = maxHP.GetValue();

    
    }

    public void AddExp(int amount)
    {
        currentXP += amount;
        if(currentXP > expToNextLevel[playerLevel])
        {
            currentXP -= expToNextLevel[playerLevel];
            playerLevel++;

        }
    }

   
}
