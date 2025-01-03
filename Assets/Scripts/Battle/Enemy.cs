using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Enemy
{
    public string name;
    public int maxHP;
    public int HP = 1;
    public int MP = 0;
    public int maxMP;
    public int ATK;
    public int DEF;
    public int INT;// intelligence
    public int RES;
    public int SPD; // speed
    public int LVL = 1;

    public bool isPlayer;

    public bool isDead;

    //public  ClassType classType;
   

}

