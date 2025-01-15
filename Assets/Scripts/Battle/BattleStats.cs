using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Battle", order = 0)]
public class BattleStats : ScriptableObject
 {

    [Header("UI")]
    public string fighterName;
   // public Sprite characterFace;
    public int maxHP;
    public  int HP = 1;
    public int MP = 0;
    public int maxMP;

    [Header("Stats")]
    public int ATK;
    public int DEF;
    public int INT;// intelligence
    public int RES;
    public int SPD; // speed

    public int LVL = 1;

    [Header("Other")]

    public bool isPlayer;
    public bool isDead;



    




    
}
