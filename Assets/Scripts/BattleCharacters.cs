using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacters : MonoBehaviour 

{
    /// <summary>
    /// Party Members
    /// </summary>
    [SerializeField] bool isPlayer;
    [SerializeField] string[] allAttacks;
    
    public string characterName;
    public int currentHP, maxHP, currentMana, maxMana, attack, magDefense, magAttack, dexterity, defense, battleLevel;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
