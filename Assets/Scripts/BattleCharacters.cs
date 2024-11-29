using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacters : MonoBehaviour

{
    /// <summary>
    /// Party Members
    /// </summary>
    /// 
    [SerializeField] bool isPlayer;
    [SerializeField] string[] allAttacks;

    [SerializeField] bool isFlipped;

   public string characterName;
    public int currentHP, maxHP, currentMana, maxMana, attack, magic, dexterity, defense, battleLevel, speed;
   [SerializeField] bool isDead;
    SpriteRenderer spr;

    Animator _anim;
    // Start is called before the first frame update

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public bool IsPlayer()
   {
    return isPlayer;
   }
   
   public int SetInitiative(int character)
   {
    speed = character;
    return character;
   }
  
}
