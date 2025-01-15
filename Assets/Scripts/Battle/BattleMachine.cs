using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Android;
using Unity.VisualScripting;
using System;
using System.Runtime.InteropServices;


public class BattleMachine : MonoBehaviour
{
    /// <summary>
    /// This is for the Course with "Jimmy and them"
    /// </summary>
    /// 
    [Header("Positions")]
    [SerializeField] Transform[] playerPositions;
    [SerializeField] Transform[] enemyPositions;

    [Header("Battle Player Information UI")]
    [SerializeField] GameObject battleUI;
    [SerializeField] GameObject characterInfoPanels;
    [SerializeField] TextMeshProUGUI playerHP;

    [SerializeField] Slider hpSliders;
    [SerializeField] TextMeshProUGUI playerMaxHP;

    [SerializeField] TextMeshProUGUI playerNameText;


    [Header("Character Battle Panels")]
    [SerializeField] GameObject enemyTargetPanel;
    [SerializeField] Button[] enemyButtons;
    [SerializeField] GameObject actionMenu;
    [SerializeField] Button use;
    [SerializeField] Button attack;
    [SerializeField] Button magic;
    [SerializeField] Button Flee;


    [SerializeField] GameObject magicPanel;
    [SerializeField] Button[] magicButtons;

    [Header("Other Battle UI")]
    //[SerializeField] GameObject actionPanel;
    [SerializeField] TextMeshProUGUI actionText;

    [Header("Battle")]
    [SerializeField] int currentTurnIndex;
    [SerializeField] List<Fighters> activeFighters = new();
    [SerializeField] List<Fighters> enemyFighters;
    [SerializeField] List<Fighters> playerFighters;

    private int playerIndex;
    private int enemyIndex;

    [SerializeField] Fighters[] players;
    [SerializeField] Fighters[] enemies;


    //[SerializeField] List<EnemyFighter> enemyFighters = new();
    // [SerializeField] List<HeroFighter> heroFighters = new();

    private float levelModifier = .02f;

    public float count;

    public bool isSummoned;

    private float maxCount = 5.0f;
    private static BattleMachine _instance;
    public static BattleMachine Instance
    {
        get
        {
            if (_instance == null)

                Debug.LogError("This " + _instance + " is null. ");

            return _instance;

        }
    }

    private bool isBattleActive;
    public int sceneNumber;

    public bool isPlayerTurn;

    public enum BattleState
    {
        Starting,

        Selecting, // this will be the player's or enemies turn

        Wait, // does the action/animation, Loop

        Win, // player

        Lose // player

    }
    public BattleState currentState;

    void Awake()
    {
        _instance = this; // probably will not need this.
    }
    // Start is called before the first frame update

    private void Start()

    {
        // scene.SetActive(false);
   

    battleUI.SetActive(false);
    
    
    }

    private void DetermineOrder()
    {
        activeFighters.Sort((c1, c2) => -c1.data.SPD.CompareTo(c2.data.SPD));
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartBattle(new string[] { "Dominic", "Paul", "Eliza" });

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextTurn();
        }

        switch (currentState)
        {
            case BattleState.Starting: // ordering the list around based on speed. 

                DetermineOrder();

             

                if (count <= 0f)
                {
                    currentState = BattleState.Selecting;
                }

                break;

            case BattleState.Selecting:
            
               ShowBattleText();
                if (isPlayerTurn) // player
                {
                    
               
                
               

          
                }   
                else 
                {
                    //activeFighters[currentTurnIndex].data.isPlayer = false;
                
              
                }
                
                break;


            case BattleState.Wait:// action

                if (activeFighters[currentTurnIndex].data.isPlayer == true)
                {
                    Debug.Log("Attack From Player");

                    //actions go here
                }
                else
                {
                    Debug.Log("Attack from Enemy");

                    //actions go here

                }
               
                break;

           

        }

        if (count <= 0f)
        {
            count = 0f;
        }
        else
        {
            count -= Time.deltaTime;
        }

    }

    private void NextTurn()
    {

        if (currentTurnIndex < activeFighters.Count - 1)
        {
            currentTurnIndex++;
        }
        else
        {
            currentTurnIndex = currentTurnIndex == 0 ? 1 : 0;
            currentTurnIndex = 0;

        }

    }

    private void Preparing()
    {
        if (!isBattleActive)
        {

            // scene.SetActive(true);
            isBattleActive = true;
            isSummoned = false;
            GameManager.Instance.isActive = true;

            //Camera.main.transform.position = new Vector3(0f, 0f, -10f);
            //transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
            LevelCharacter.Instance.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneNumber);
        }

    }

    public void StartBattle(string[] enemies)
    {

        Preparing();
        AddPlayers();
        AddEnemies(enemies);

        count = maxCount;

      

        isPlayerTurn = true;
        currentTurnIndex = 0;
        /// battle order
        //UpdatePlayerStats();

        currentState = BattleState.Starting;

    }




    private void AddPlayers()
    {

        for (int i = 0; i < players.Length; i++)
        {

            Fighters newPlayer = Instantiate(players[i], playerPositions[i].position, playerPositions[i].rotation, playerPositions[i]);
            playerFighters.Add(newPlayer);
            activeFighters.Add(newPlayer);

            newPlayer.data.HP = players[i].data.HP;
            newPlayer.data.MP = players[i].data.MP;
            newPlayer.data.maxHP = players[i].data.maxHP;
            newPlayer.data.maxMP = players[i].data.maxMP;
            newPlayer.data.ATK = players[i].data.ATK;
            newPlayer.data.DEF = players[i].data.DEF;
            newPlayer.data.SPD = players[i].data.SPD;
            newPlayer.data.INT = players[i].data.INT;
            newPlayer.data.RES = players[i].data.RES;




        }


    }


    private void AddEnemies(string[] enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn.Length; i++)
        {
            if (enemiesToSpawn[i] != "")
            {
                for (int j = 0; j < enemies.Length; j++)
                {
                    if (enemies[j].data.fighterName == enemiesToSpawn[i])
                    {
                        Fighters newEnemy = Instantiate(enemies[j], enemyPositions[i].position, enemyPositions[i].rotation, enemyPositions[i]);

                        enemyFighters.Add(newEnemy);
                        activeFighters.Add(newEnemy);

                        newEnemy.name = enemies[j].data.fighterName;
                        newEnemy.data.LVL = enemies[j].data.LVL;

                        float levelMod = levelModifier * newEnemy.data.LVL;

                        newEnemy.data.HP = Mathf.CeilToInt(enemies[j].data.HP * levelMod + enemies[j].data.HP);
                        newEnemy.data.maxHP = Mathf.CeilToInt(enemies[j].data.maxHP * levelMod + enemies[j].data.maxHP);
                        newEnemy.data.MP = Mathf.CeilToInt(enemies[j].data.MP * levelMod + enemies[j].data.maxMP);
                        newEnemy.data.maxMP = Mathf.CeilToInt(enemies[j].data.maxMP * levelMod + enemies[j].data.maxMP);
                        newEnemy.data.ATK = Mathf.CeilToInt(enemies[j].data.ATK * levelMod + enemies[j].data.ATK);
                        newEnemy.data.DEF = Mathf.CeilToInt(enemies[j].data.DEF * levelMod + enemies[j].data.DEF);
                        newEnemy.data.INT = Mathf.CeilToInt(enemies[j].data.INT * levelMod + enemies[j].data.INT);
                        newEnemy.data.RES = Mathf.CeilToInt(enemies[j].data.RES * levelMod + enemies[j].data.RES);
                        newEnemy.data.SPD = Mathf.CeilToInt(enemies[j].data.SPD * levelMod + enemies[j].data.SPD);



                        // enemyFighters.Add(enemyFighters[i]);
                        //Debug.Log(newEnemy);

                    }
                }
            }

        }


    }

    public void ShowBattleText()
    {
       actionText.text = activeFighters[currentTurnIndex].data.fighterName + " 's " + " turn. ";

    }
    
   

    public void EnemySelection()
    {
        actionMenu.SetActive(false);
        SetEnemyTargets();
        enemyTargetPanel.SetActive(true);



    }

    void SetEnemyTargets()
    {
        for (int i = 0; i < enemyButtons.Length; i++)
        {

            enemyButtons[i].gameObject.SetActive(false);


        }
        for (int j = 0; j < enemies.Length; j++)// list later;
        {
            enemyButtons[j].gameObject.SetActive(true);
            enemyButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = enemies[j].data.fighterName;





        }


    }






}



