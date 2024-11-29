using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerData : MonoBehaviour // debating on whether to make this a scriptable object.
{
    public string playerName;
    [SerializeField] Sprite characterImage;
    [SerializeField] int playerLevel = 1; // thinking about it
    [SerializeField] int currentXP;
    [SerializeField] int[] xpForNextLevel;
    public int maxHP;
     public  int currentHP = 1;
     public int currentMP;
    public int MaxMP;
    public int defense;
    public int attack;
    public int magic;// intelligence
    public  int speed;
   public int dexterity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
