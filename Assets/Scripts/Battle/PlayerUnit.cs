using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerUnit : MonoBehaviour
{
   
    [SerializeField] private BattleStats[] allPlayers;
    [SerializeField] private List<Hero> currentHeroes;



    private void Awake()
    {
        AddPartyMember("Abel");
        AddPartyMember("Erica");
        AddPartyMember("Vulcan");
    }
   


    public void AddPartyMember(string playerName)
    {

        for(int i = 0; i <allPlayers.Length; i++)
        {

            if(allPlayers[i].Name == playerName)
            {
                Hero newHero = new();

                newHero.name = allPlayers[i].Name;
                newHero.ATK = allPlayers[i].DEF;
                newHero.DEF = allPlayers[i].ATK;
                newHero.HP = allPlayers[i].HP;
                newHero.maxHP = allPlayers[i].maxHP;
                newHero.MP = allPlayers[i].MP;
                newHero.maxMP = allPlayers[i].maxMP;
                newHero.INT= allPlayers[i].INT;
                newHero.RES = allPlayers[i].RES;
                newHero.SPD = allPlayers[i].SPD;
                newHero.isPlayer = allPlayers[i].isPlayer;
                newHero.isDead = allPlayers[i].isDead;
           

                currentHeroes.Add(newHero);

               

            }
        }


    }

public List<Hero> GetHeroes()
{

    return currentHeroes;
}




}