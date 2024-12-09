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
    /// 

    [SerializeField] private enum BattleStates {Start, Selection, Battle, Won, Lost, Run, Using} 
    // idle is for selection, busy for animation
    // Using is for items after selection - take a turn
    [Header("Battle")]
    [Serialize] BattleStates battleState;
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
    [SerializeField] GameObject battleUI, actionMenu, magicMenu, enemySelectionMenu;
    [SerializeField] TextMeshProUGUI actionLabelText, nameText; //Character nameText;

    //For each enemy and Player Active Character
    [SerializeField] TextMeshProUGUI hpPlayerInformation1, hpPlayerInformation2, hpEnemyInformation1, hpEnemyInformation2; // at the top
    [SerializeField] private Slider hpPlayerSlider, hpEnemySlider; // at the top

    [SerializeField] Button actionButton, magicButton, useButton;

    [SerializeField] int currentTurn;
    [SerializeField] bool waitingForTurn;

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
            StartBattle(new string[] { "Dominic", "Paul", "Zena", "Eliza", "Zephyr" });

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextTurn();
        }

        if (isBattleActive)
        {
            
            if (waitingForTurn)
            {
                
                if (activeCharacters[currentTurn].IsPlayer())
                {

                    battleUI.SetActive(true);
                    
                    
                }
                else
                {   
                   battleUI.SetActive(false);
                    
                }
                
            }
        }
        UpdateHealthBars();
    }
    public void StartBattle(string[] enemies)
    {

        Preparing();
        AddPlayers();
        AddEnemies(enemies);

        waitingForTurn = true;
        currentTurn = 0;
        /// battle order


    }


    private void AddPlayers()
    {
        for (int i = 0; i < GameManager.Instance.GetPlayers().Length; i++)
        {
            if (GameManager.Instance.GetPlayers()[i].gameObject.activeInHierarchy)
            {
                for (int j = 0; j < playerCharacters.Count; j++)
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
                if (enemyCharacters[i].gameObject.activeInHierarchy)
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
        if (currentTurn >= activeCharacters.Count)
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

    private IEnumerator BattleLoop()
    {
        yield return null;
        enemySelectionMenu.SetActive(false);
        battleState = BattleStates.Battle;
        // popup
        

        for(int i = 0; i < activeCharacters.Count; i++)
        {
           
        }
    }

/*
    public void SetValues(int health, int maxHealth)// information panel
    {
        for (int i = 0; i < activeCharacters.Count; i++)
            if (activeCharacters[i].IsPlayer() == true)
            {
                playerCharacters[currentTurn].currentHP = health;
                playerCharacters[currentTurn].maxHP = maxHealth;
                hpPlayerInformation1.text = playerCharacters[currentTurn].currentHP.ToString();
                hpPlayerInformation2.text = playerCharacters[currentTurn].maxHP.ToString();
            }
            else
            {
                enemyCharacters[currentTurn].currentHP = health;
                enemyCharacters[currentTurn].maxHP = maxHealth;
                hpEnemyInformation1.text = enemyCharacters[currentTurn].currentHP.ToString();
                hpEnemyInformation2.text = enemyCharacters[currentTurn].maxHP.ToString();
            }
        UpdateHealthBars();

    }
    */
    private void UpdateHealthBars()
    {
       
        
    }

    public void ShowBattleMenu() // for active characters
    {
        for (int i = 0; i < playerCharacters.Count; i++)
        {
            actionLabelText.text = activeCharacters[currentTurn].name;
            actionMenu.SetActive(true);
        }

    }
    public void ShowMagicSelectionMenu() // magic button.. seperate function for spells
    {
        magicMenu.SetActive(true);
    }

    public void ShowTargetMenu() // for any targeting buttons
    {
        //if()
        actionMenu.SetActive(false);
        magicMenu.SetActive(false);
        SetEnemySelection();
        enemySelectionMenu.SetActive(true);
    }

    private void SetEnemySelection()
    {
        for (int i = 0; i < enemyTargetButtons.Length; i++)
        {
            enemyTargetButtons[i].SetActive(false);

        }
        for (int j = 0; j < enemyCharacters.Count; j++)
        {
            enemyTargetButtons[j].SetActive(true);
            enemyTargetButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = enemyCharacters[j].characterName;
        }
    }
    //// show mana cost and ability name for each available characters. Enemies too.


    private void SetSpellSelection()
    {
        for (int i = 0; i < enemyTargetButtons.Length; i++) /// spellAttackButtons
        {
            //spell buttons[].SetActive(false);
            //enemyTargetButtons[i].SetActive(false);

        }
        for (int j = 0; j < enemyCharacters.Count; j++)
        {
            enemyTargetButtons[j].SetActive(true); //spell buttons
            enemyTargetButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = enemyCharacters[j].characterName; // spell name
        }
    }
    private void DetermineOrder()
    {


        activeCharacters.Sort((c1, c2) => -c1.speed.CompareTo(c2.speed));
        //activeCharacters.Sort((c1,c2) => -c1.SetInitiative().CompareTo(c2.SetInitiative(activeCharacters[activeCharacters.Count].speed)));
    }

   

}
