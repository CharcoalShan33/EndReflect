using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.U2D.IK;

public class BattleSystem : MonoBehaviour
{
/// <summary>
/// PartyMemberInfo = PlayerStats 
//EnemyInfo = BattleInfo for Enemies
////PartyMember = uses Playerstats;

//EnemyMember = uses enemyStats;
//BattleEntities = BattleCharacter


/// </summary>
    private bool isBattleActive;
    [SerializeField] int sceneNumber;
    [SerializeField] GameObject scene;
    [SerializeField] Transform[] playerPositions, enemyPositions;

    //[SerializeField] BattleCharacters[] players, enemies;

    
    [SerializeField] List<BattleCharacters> activeCharacters;
    [SerializeField] List<BattleCharacters> playerCharacters;
     [SerializeField] List<BattleCharacters> enemyCharacters;

    //[SerializeField] BattleCharacters defaultPlayer;
    [Header("UI")]

    [SerializeField]
    GameObject[] enemyTargetButtons;
    [SerializeField]GameObject battleUI, actionMenu, magicMenu, enemySelectionMenu;
    [SerializeField] TextMeshProUGUI actionLabelText , nameText; //Character nameText;

//For each enemy and Player Active Character
    [SerializeField] TextMeshProUGUI hpPlayerInformation1, hpPlayerInformation2, hpEnemyInformation1, hpEnemyInformation2;
    [SerializeField] private Slider hpPlayerSlider,hpEnemySlider;
    
    

    [SerializeField] int currentTurn;
    [SerializeField] bool waitingForTurn;

    private int currentPlayer;

    // Start is called before the first frame update

    private void Start()

    { 
        
     
        scene.SetActive(false);
        battleUI.SetActive(false);
        
         DetermineOrder();

      
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartBattle(new string[]{"Dominic","Paul","Zena","Eliza","Zephyr"});
            
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            NextTurn();
        }
      
       if(isBattleActive)
       {
        if(waitingForTurn)
        {
            if(activeCharacters[currentPlayer].IsPlayer())
            {
                
                battleUI.SetActive(true);
            }
            else
            {
                battleUI.SetActive(false);
            }
        }
       }

    }
    public void StartBattle(string[] enemies)
    {
      
        Preparing();
       AddPlayers();
       AddEnemies(enemies);
       
       waitingForTurn = true;
       currentTurn = 0;
       

    }

 
    private void AddPlayers()
    {
         for (int i = 0; i < GameManager.Instance.GetPlayers().Length; i++)
        {
           if(GameManager.Instance.GetPlayers()[i].gameObject.activeInHierarchy)
            {
                for (int j = 0; j < playerCharacters.Count ; j++)
                {
                    if (playerCharacters[j].characterName == GameManager.Instance.GetPlayers()[i].playerName)
                    {
                        BattleCharacters newPlayer = Instantiate(playerCharacters[j], playerPositions[i].position, playerPositions[i].rotation);
                        activeCharacters.Add(newPlayer);
                     
                    PlayerData player = GameManager.Instance.GetPlayers()[i];
                    activeCharacters[i].currentHP = player.currentHP;
                    activeCharacters[i].currentMana = player.currentMP;
                    activeCharacters[i].maxHP = player.maxHP;
                    activeCharacters[i].maxMana = player.MaxMP;
                    activeCharacters[i].attack = player.attack;
                    activeCharacters[i].defense = player.defense;
                    activeCharacters[i].speed = player.speed;
                    activeCharacters[i].dexterity = player.dexterity;
                    activeCharacters[i].magic = player.magic;
                

                    }
                }
             }
            
        }
    }

    private void AddEnemies(string[] enemiesToSpawn)
    {
       for (int i = 0; i < enemyCharacters.Count; i++)
        {
            if (enemiesToSpawn[i] != "")
            {
                if(enemyCharacters[i].gameObject.activeInHierarchy)
                {
                for (int j = 0; j < enemyCharacters.Count; j++)
                {
                    if (enemyCharacters[j].characterName == enemiesToSpawn[i])
                    {

                        BattleCharacters newEnemy = Instantiate(enemyCharacters[j], enemyPositions[i].position, enemyPositions[i].rotation);
                        activeCharacters.Add(newEnemy);

                    }
                }
                }
            }
        }
    }

    private void Preparing()
    {
        if (!isBattleActive)
        {
           scene.SetActive(true);
            isBattleActive = true;
            GameManager.Instance.Active = true;
        
            //Camera.main.transform.position = new Vector3(0f, 0f, -10f);
            //transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
            PlayerController.instance.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneNumber);
        }

    }

    void NextTurn()
    {
        currentTurn++;
        if(currentTurn >= activeCharacters.Count)
        {
            currentTurn = 0;
        }
    }

    public void ShowCurrentPlayerInformation()
    {

    }
    public void ShowCurrentEnemyInformation()
    {

    }

    public void SetValues(int healith, int maxHealth, int speed)
    {
         for(int i = 0; i < playerCharacters.Count; i++)
        
            playerCharacters[0].currentHP = healith;
            playerCharacters[0].maxHP = maxHealth;
            hpPlayerInformation1.text = playerCharacters[0].currentHP.ToString();
            hpPlayerInformation2.text = playerCharacters[0].maxHP.ToString();

            UpdateHealthBars();
        
    }
    private void UpdateHealthBars()
    {
        //foreach 
        hpPlayerSlider.maxValue = playerCharacters[0].maxHP;
        hpPlayerInformation1.text = playerCharacters[0].currentHP.ToString();
        hpPlayerSlider.value = playerCharacters[0].currentHP;
    }

   public void ShowBattleMenu() // for active characters
   {
    actionLabelText.text = activeCharacters[currentPlayer].name;
    actionMenu.SetActive(true);
   }
   public void ShowMagicMenu()
   {
     magicMenu.SetActive(true);
   }

    public void ShowTargetMenu()
    {
        actionMenu.SetActive(false);
        magicMenu.SetActive(false);
        SetEnemySelection();
        enemySelectionMenu.SetActive(true);
    }

    private void SetEnemySelection()
    {
        for(int i = 0; i < enemyTargetButtons.Length; i++)
        {
            enemyTargetButtons[i].SetActive(false);
            
        }
        for(int j = 0; j< enemyCharacters.Count; j++)
        {
            enemyTargetButtons[j].SetActive(true);
            enemyTargetButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = enemyCharacters[j].characterName;
        }
    }
    //// show mana cost and ability name for each available characters. Enemies too.

    private void DetermineOrder()
    {
       
     
     activeCharacters.Sort((c1,c2) => -c1.speed.CompareTo(c2.speed));
    //activeCharacters.Sort((c1,c2) => -c1.SetInitiative().CompareTo(c2.SetInitiative(activeCharacters[activeCharacters.Count].speed)));
    }

    

}
