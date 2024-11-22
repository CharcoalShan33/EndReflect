using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartyManager : MonoBehaviour
{
    private bool isBattleActive;

    [SerializeField] int sceneNumber;
    [SerializeField] Transform[] playerPositions, enemyPositions;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] BattleCharacters[] battlers;
    [SerializeField] List<BattleCharacters> currentBattler;

    [SerializeField] BattleCharacters defaultBattler;
    // Start is called before the first frame update
    void Start()
    {
        GetPartyByName(defaultBattler.characterName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle()
    {

    }

    public void GetPartyByName(string memberName)
    {
        for(int i= 0; i < battlers.Length; i++)
        {
             if(battlers[i].characterName == memberName)
             {
                BattleCharacters newCharacters = new BattleCharacters();
                newCharacters.characterName = battlers[i].characterName;
                newCharacters.currentHP = battlers[i].currentHP;

                currentBattler.Add(newCharacters);
             }
        }
    }

}
