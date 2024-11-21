using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacters : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] string[] allAttacks;
    
    public string characterName;
    public int currentHP, maxHP, currentMana, maxMana, attackPower, defensePower, dexterity, defense;
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
