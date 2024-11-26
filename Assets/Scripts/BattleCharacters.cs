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


   [SerializeField] string characterName;
    [SerializeField] int currentHP, maxHP, currentMana, maxMana, attack, magDefense, magAttack, dexterity, defense, battleLevel;
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
}
