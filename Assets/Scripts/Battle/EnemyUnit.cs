using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class EnemyUnit : MonoBehaviour

{

    [SerializeField] private BattleStats[] allEnemies;
    [SerializeField] private List<Enemy> currentEnemies;

    private const float Level_Modifier = .02f;



    private   void Awake()
    {
        AddPartyMember("Aiden");
        AddPartyMember("Dominic");
        AddPartyMember("Paul");
    }
   


    public void AddPartyMember(string enemyName)
    {

        for(int i = 0; i <allEnemies.Length; i++)
        {

            if(allEnemies[i].Name == enemyName)
            {
                Enemy newEnemy = new();

                newEnemy.name = allEnemies[i].Name;
                newEnemy.LVL = allEnemies[i].LVL;

                float levelModifier = Level_Modifier * newEnemy.LVL;

                newEnemy.ATK = Mathf.CeilToInt(allEnemies[i].ATK +( allEnemies[i].ATK * levelModifier) );
                newEnemy.DEF = Mathf.CeilToInt(allEnemies[i].DEF +( allEnemies[i].DEF * levelModifier) );
                newEnemy.INT = Mathf.CeilToInt(allEnemies[i].INT +( allEnemies[i].INT * levelModifier) );
                newEnemy.RES = Mathf.CeilToInt(allEnemies[i].RES +( allEnemies[i].RES * levelModifier) );
                newEnemy.SPD = Mathf.CeilToInt(allEnemies[i].SPD +( allEnemies[i].SPD * levelModifier) );
                newEnemy.HP = Mathf.CeilToInt(allEnemies[i].HP +( allEnemies[i].HP * levelModifier) );
                newEnemy.MP = Mathf.CeilToInt(allEnemies[i].MP +( allEnemies[i].MP * levelModifier) );
                newEnemy.maxHP = Mathf.CeilToInt(allEnemies[i].maxHP +( allEnemies[i].maxHP* levelModifier) );
                newEnemy.maxMP = Mathf.CeilToInt(allEnemies[i].maxMP +( allEnemies[i].maxMP * levelModifier) );

                currentEnemies.Add(newEnemy);

            }
        }


    }

    public List<Enemy> GetEnemies()
    {

        return currentEnemies;
    }


}
