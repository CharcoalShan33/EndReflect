using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    [Header("Stat Information")]
    public string playerName;
    public Sprite characterImage;
    public int playerLevel = 1;
    [Header("Experience")]

    public int currentXP;

    public int baseXPAmount;

    public int[] expToNextLevel; // no reference
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

    [Header("Others")]
    public bool isPlayer;
    public bool isDead;

    [Header("Equipment")]

    public int weaponPower;
    public int armorPower;

    public int magicPower;

    public int resistPower;

    public int speedIncrease;

    [Header("Sanity Meter")]
    public int friendship;

    public int sanity;

    public int maxSanity;



    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseXPAmount;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {

            expToNextLevel[i] = (4* playerLevel^3)/5;

            attack++;
            defense++;
            magic++;
            speed++;
            magicDefense++;

        }
    }
    

    public void Healing(int heal)
    {
        int healAmount = (int)(heal + (maxHP * .33f));
        currentHP = Mathf.Min(currentHP + healAmount, maxHP);

        currentHP+= healAmount;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
    public void Resting(int rest)
    {
        int restAmount = (int)(rest + (MaxMP * .25f));
        currentMP = Mathf.Min(currentMP + restAmount, MaxMP);

        currentMP+= restAmount;
        if(currentMP > MaxMP)
        {
            currentMP = MaxMP;
        }
    }

    public void AddExperience(int amount)
    {
        currentXP += amount;
        if(currentHP > expToNextLevel[playerLevel])
        {
            playerLevel++;
        }
    }
    // XP = (4*level^3)/5
}
