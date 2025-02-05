using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Android;
using Unity.VisualScripting;

using System.Runtime.InteropServices;
using System.Data;
using UnityEngine.InputSystem.LowLevel;






public class BattleMachine : MonoBehaviour
{
    /// <summary>
    /// </summary>
    /// 
    [Header("Positions")]
    [SerializeField] Transform[] playerPositions;
    [SerializeField] Transform[] enemyPositions;

    [Header("Battle Player Information UI")]
    [SerializeField] GameObject battleUI;
    [SerializeField] GameObject[] characterInfoPanels;
    [SerializeField] TextMeshProUGUI[] playerHP;

    [SerializeField] Slider[] hpSliders;
    [SerializeField] TextMeshProUGUI[] playerMaxHP;

    [SerializeField] TextMeshProUGUI[] playerNameText;


    [Header("Character Battle Panels")]
    [SerializeField] GameObject enemyTargetPanel;
    [SerializeField] TargetButtons[] enemyButtons;
    [SerializeField] GameObject actionMenu;
    [SerializeField] Button use;
    [SerializeField] Button attack;
    [SerializeField] Button magic;
    [SerializeField] Button Flee;


    [SerializeField] GameObject magicPanel;
    [SerializeField] MagicAttackButtons[] magicButtons;



    [Header("Other Battle UI")]
    //[SerializeField] GameObject actionPanel;
    [SerializeField] TextMeshProUGUI actionText;

    [SerializeField] DamageTextScript damageText;

    [Header("Battle")]
    [SerializeField] int currentTurnIndex;

    [SerializeField] List<Fighters> activeFighters = new();
    [SerializeField] List<Fighters> enemyFighters = new();
    [SerializeField] List<Fighters> playerFighters = new(); // 

    [SerializeField] Fighters[] players;
    [SerializeField] Fighters[] enemies;

    [SerializeField] Spells[] SpellList;
    [SerializeField] Attacks[] attackList;

    [SerializeField] BattleMoves[] movesList;

    [Header("Numbers")]

    public bool isFullTurn;

    [SerializeField] int fullTurn;

    [SerializeField] float wait;

    [SerializeField] float chance = .25f;
    public bool waitForTurn;

    //public float count;

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



    private bool allEnemiesDead;
    private bool allPlayersDead;

    private bool isBattleActive;
    //public int sceneNumber;



    ShakeScript shaker;

    bool isCritical;
    bool canRun;

    Vector3 offset = new(0f, 1, 0f);
    WaitForSeconds waitFor = new(.5f);
    WaitForSeconds reallyWaitFor = new(1f);

    bool isSummon;


    void Awake()
    {
        if (_instance != this && _instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }// probably will not need this. 

    }
    // Start is called before the first frame update

    private void Start()

    {


        // scene.SetActive(false);

        // DetermineOrder();
        battleUI.SetActive(false);

        DontDestroyOnLoad(gameObject);

        chance = .25f;


        //spawnManager = FindFirstObjectByType<Spawner>();


    }

    private void DetermineOrder()
    {
        activeFighters.Sort((c1, c2) => -c1.fighterData.Dexterity.CompareTo(c2.fighterData.Dexterity));
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && isSummon == false)
        {
            
            StartBattle(new string[] { "Dominic", "Paul", "Eliza" });
            battleUI.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.N) && isBattleActive)
        {
            NextTurn();
        }

        CheckTurns();

        if (isCritical)
        {
            damageText.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
            //shaker.Tremor(.15f, 1.25f, 0.6f);
        }
        else
        {
            damageText.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }

       



        if (chance >= 1.0f)
        {
            chance = 1.0f;
        }
        if (canRun)
        {
            ResetChance();
        }




    }
    private void CheckTurns()

    {
        if (isBattleActive)
        {
            if (waitForTurn)
            {

                if (activeFighters[currentTurnIndex].fighterData.isPlayer)
                {
                    actionMenu.SetActive(true);

                    //ShowBattleText();
                }

                else
                {
                    actionMenu.SetActive(false);
                    //ShowBattleText();

                    //battleUI.SetActive(false);
                    StartCoroutine(EnemyMovement());

                }
            }

        }


    }

    private void NextTurn()
    {

        if (currentTurnIndex < activeFighters.Count - 1)
        {
            currentTurnIndex++;
            isFullTurn = false;
        }
        else
        {
            //currentTurnIndex = currentTurnIndex == 0 ? 1 : 0; // if the turn is zero which is false, set it 1 one as true. if true, set it to false again.
            currentTurnIndex = 0;
            isFullTurn = true;
            fullTurn++;

        }
        waitForTurn = true;

        BattleConditions();
        UpdatePlayerStats();


    }


    public void StartBattle(string[] enemies)
    {
        Preparing();

        AddPlayers();
        AddEnemies(enemies);
        // count = maxCount;
        waitForTurn = true;
        currentTurnIndex = 0;


        /// battle order
        UpdatePlayerStats();
        // currentState = BattleState.Starting;

    }

    private void Preparing()
    {
        if (!isBattleActive)
        {

            // scene.SetActive(true);
            isBattleActive = true;
            GameManager.Instance.isActive = true;

            //Camera.main.transform.position = new Vector3(0f, 0f, -10f);
            //transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
            LevelCharacter.Instance.gameObject.SetActive(false);
          

            UIManager.Instance.FadeInBlack();
            StartCoroutine(LoadBattle());
            wait = 1.0f;
        }

    }

    private IEnumerator LoadBattle()
    {
       // Camera.main.transform.position = new Vector3(0f, 0f, -10f);
        //transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
        LevelCharacter.Instance.gameObject.SetActive(false);


        while (wait >= 0f)
        {
            wait -= Time.deltaTime;
            yield return null;

        }
        UIManager.Instance.FadeOutBlack();
        SceneManager.LoadScene(5);
        
        yield return new WaitForSeconds(1.5f);
        wait = 0.0f;

    }

    private void AddPlayers()
    {

        for (int i = 0; i < players.Length; i++)
            {
                
                    Fighters newPlayer = Instantiate(players[i], playerPositions[i].position, playerPositions[i].rotation, playerPositions[i]);
                    playerFighters.Add(newPlayer);
                    activeFighters.Add(newPlayer);
                    isSummon = true;
                    newPlayer.gameObject.SetActive(true);
                }
            
        


    }

    public void Pass()
    {
        while (!isFullTurn)
        {
            activeFighters[currentTurnIndex].Defend();
            break;
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
                        activeFighters.Add(newEnemy);
                        enemyFighters.Add(newEnemy);
                        isSummon = true;

                    }
                }
            }

        }
    }

    public IEnumerator EnemyMovement()
    {

        waitForTurn = false;

        yield return new WaitForSeconds(.75f);

        EnemyAttacking();

        yield return new WaitForSeconds(.75f);

        NextTurn();


    }


    private void BattleConditions()

    {
        for (int i = 0; i < activeFighters.Count; i++)
        {
            if (activeFighters[i].fighterData.health <= 0)
                activeFighters[i].fighterData.health = 0;


            if (activeFighters[i].fighterData.health == 0)
            {
                if (activeFighters[i].fighterData.isPlayer && !activeFighters[i].fighterData.isDead)
                {
                    activeFighters[i].DeathToPlayer();
                    // activeFighters.Remove(activeFighters[i]);
                    // playerFighters.Remove(activeFighters[i]);
                }
                if (!activeFighters[i].fighterData.isPlayer && !activeFighters[i].fighterData.isDead)
                {
                    activeFighters[i].DeathToEnemy();
                    //activeFighters.Remove(activeFighters[i]);
                    //enemyFighters.Remove(activeFighters[i]);
                }
            }
            else
            {
                if (activeFighters[i].fighterData.isPlayer)
                    allPlayersDead = false;
                else
                    allEnemiesDead = false;
            }

            if (allEnemiesDead || allPlayersDead)
            {
                if (allEnemiesDead)
                {
                    StartCoroutine(EndBattle());
                    //StartCoroutine(ExitBattle());

                    GameManager.Instance.didWin = true;

                }
                else if (allPlayersDead)
                {
                     StartCoroutine(ExitBattle());

                    GameManager.Instance.didWin = false;
                }


                // SceneManager.LoadScene(2);
                //isBattleActive = false;
                // GameManager.Instance.isActive = false;

            }
            else
            {
                while (activeFighters[currentTurnIndex].fighterData.health == 0)
                {
                    currentTurnIndex++;
                    if (currentTurnIndex >= activeFighters.Count)
                    {
                        currentTurnIndex = 0;
                    }
                }
            }

        }

    }

    public void TargetMenu(string moveName)
    {
        enemyTargetPanel.SetActive(true);

        List<int> enemy = new();

        for (int i = 0; i < activeFighters.Count; i++)
        {
            if (!activeFighters[i].fighterData.isPlayer)
            {
                enemy.Add(i);
            }
        }

        for (int i = 0; i < enemyButtons.Length; i++)
        {
            if (enemy.Count > i && activeFighters[enemy[i]].fighterData.health > 0)
            {
                enemyButtons[i].gameObject.SetActive(true);
                // enemyButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = enemies[i].data.fighterName;
                enemyButtons[i].activeBattleTarget = enemy[i];
                enemyButtons[i].moveName = moveName;
                enemyButtons[i].targetName.text = activeFighters[enemy[i]].fighterData.fighterName;
            }
            else
            {

                enemyButtons[i].gameObject.SetActive(false);
            }
        }

    }
    public void OpenMagicMenu()
    {
        magicPanel.SetActive(true);

        for (int i = 0; i < magicButtons.Length; i++)
        {
            if (activeFighters[currentTurnIndex].AllAttacks().Length > i)
            {
                magicButtons[i].gameObject.SetActive(true);
                // enemyButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = enemies[i].data.fighterName;

                magicButtons[i].spellName = GetActiveFighter().AllAttacks()[i];
                magicButtons[i].spellNameText.text = magicButtons[i].spellName;

                for (int j = 0; j < movesList.Length; j++)
                {
                    if (movesList[j].moveAttackName == magicButtons[i].spellName)
                    {
                        magicButtons[i].spellCost = movesList[j].manaCost;
                        magicButtons[i].spellCostText.text = magicButtons[i].spellCost.ToString();
                    }
                }
            }
            else
            {
                magicButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public bool OpenMagicAttackMenu(bool open)
    {
        magicPanel.SetActive(open);
        return open;
    }

    public Fighters GetActiveFighter()
    {

        return activeFighters[currentTurnIndex];
    }
    private void EnemyAttacking()
    {

        List<int> heroes = new();


        for (int i = 0; i < activeFighters.Count; i++)
        {
            if (activeFighters[i].fighterData.isPlayer && activeFighters[i].fighterData.health != 0)
            {
                heroes.Add(i);
            }
        }

        int selectPlayer = heroes[Random.Range(0, playerFighters.Count)];


        int getSpell = Random.Range(0, activeFighters[currentTurnIndex].AllAttacks().Length);
        int movePower = 0;

        for (int i = 0; i < movesList.Length; i++)
        {
            if (movesList[i].moveAttackName == activeFighters[currentTurnIndex].AllAttacks()[getSpell])
            {

                //activeFighters[enemyFighters.Count].CastingSpell(activeFighters[enemyFighters.Count].availableSpells[getSpell],activeFighters[selectPlayer] );
                //SpellList[i].CastSpell(activeFighters[selectPlayer]);
                Instantiate(movesList[i].effect, activeFighters[selectPlayer].transform.position, activeFighters[selectPlayer].transform.rotation);


                movePower = movesList[i].movePower;

                // currentState = BattleState.Waiting; 
            }
        }
        // select enemy  effect here

        if (movesList[getSpell].current == BattleMoves.BattleMoveType.physical)
        {
            DealDamage(selectPlayer, movePower);

        }
        else if (movesList[getSpell].current == BattleMoves.BattleMoveType.magic)
        {
            DealMagicDamage(selectPlayer, movePower);
        }


        //DealDamage(selectPlayer, movePower);
        UpdatePlayerStats();

    }

    public void PlayerAttacking(string attack, int selectEnemy) // fighter
    {

        int getMove = activeFighters[currentTurnIndex].AllAttacks().Length;
        //int selectEnemy = 3;
        int movePower = 0;


        for (int i = 0; i < movesList.Length; i++)
        {

            if (movesList[i].moveAttackName == attack)
            {
                movePower = ThrowAttack(selectEnemy, i);
            }
        }
        // effect here
        if (movesList[getMove].current == BattleMoves.BattleMoveType.physical)
        {
            DealDamage(selectEnemy, movePower);


        }
        else if (movesList[getMove].current == BattleMoves.BattleMoveType.magic)
        {
            DealMagicDamage(selectEnemy, movePower);

        }


        NextTurn();
        //UpdatePlayerStats();
        enemyTargetPanel.SetActive(false);


    }

    private int ThrowAttack(int selectEnemy, int i)
    {
        int movePower;
        //activeFighters[enemyFighters.Count].CastingSpell(activeFighters[enemyFighters.Count].availableSpells[getSpell],activeFighters[selectPlayer] );
        //SpellList[i].CastSpell(activeFighters[selectPlayer]);

        Instantiate(movesList[i].effect, activeFighters[selectEnemy].transform.position, activeFighters[selectEnemy].transform.rotation);

        movePower = movesList[i].movePower;
        // currentState = BattleState.Waiting; 
        return movePower;
    }

    public void DealDamage(int selectedFighter, int movePower)
    {

        float attackPower = activeFighters[selectedFighter].fighterData.Attack; // weapon power

        float defensePower = activeFighters[selectedFighter].fighterData.Defense; // armor power


        float damageAmount = attackPower / defensePower * movePower;

        int damageToGive = (int)damageAmount;

        damageToGive = CalculateCriticalDamage(damageToGive);

        Debug.Log(activeFighters[currentTurnIndex] + " dealing " + "(" + damageToGive + ") to " + activeFighters[selectedFighter]);

        activeFighters[selectedFighter].TakeDamage(damageToGive);

        DamageTextScript newDamage = Instantiate(damageText, activeFighters[selectedFighter].transform.position, activeFighters[selectedFighter].transform.rotation);
        newDamage.SetDamage(damageToGive);
        UpdatePlayerStats();

    }

    public void DealMagicDamage(int selectedFighter, int movePower)
    {

        float magicPower = activeFighters[selectedFighter].fighterData.Intelligence; // weapon power

        float resistPower = activeFighters[selectedFighter].fighterData.Resistance; // armor power


        float damageAmount = magicPower / resistPower * movePower;

        int damageToGive = (int)damageAmount;

        damageToGive = CalculateCriticalDamage(damageToGive);

        Debug.Log(activeFighters[currentTurnIndex] + " dealing " + "(" + damageToGive + ") to " + activeFighters[selectedFighter]);

        activeFighters[selectedFighter].TakeDamage(damageToGive);

        DamageTextScript newDamage = Instantiate(damageText, activeFighters[selectedFighter].transform.position, activeFighters[selectedFighter].transform.rotation);
        newDamage.SetDamage(damageToGive);
        UpdatePlayerStats();


    }

    private int CalculateCriticalDamage(int _damage)
    {

        //float totalCritPower = activeFighters[currentTurnIndex].data.ATK + (activeFighters[currentTurnIndex].data.ATK / activeFighters[currentTurnIndex].data.SPD);

        float totalCritPower = activeFighters[currentTurnIndex].fighterData.Attack * 0.05f;

        float critDamage = _damage * totalCritPower;

        if (Random.value <= 0.2f)

        {
            isCritical = true;
            Debug.Log("Critical!" + critDamage);
            return Mathf.RoundToInt(critDamage);

        }

        return Mathf.RoundToInt(_damage);


    }

    public void UpdatePlayerStats()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (activeFighters.Count > i)// if they are active
            {
                if (activeFighters[i].fighterData.isPlayer)
                {

                    characterInfoPanels[i].SetActive(true);
                    Fighters playerData = activeFighters[i];

                    playerNameText[i].text = playerData.fighterData.fighterName;
                    playerHP[i].text = playerData.fighterData.health.ToString();
                    playerMaxHP[i].text = playerData.fighterData.maxHealth.ToString();
                    hpSliders[i].maxValue = playerData.fighterData.maxHealth;
                    hpSliders[i].value = playerData.fighterData.health;
                   //playerData.gameObject.SetActive(true);

                }
                else
                {
                    characterInfoPanels[i].SetActive(false);
                    //playerFighters.Remove(playerFighters[i]);
                    activeFighters[i].gameObject.SetActive(false);
                }
            }
            else
            {
                characterInfoPanels[i].SetActive(false);
                activeFighters[i].gameObject.SetActive(false);
               // playerFighters.Remove(playerFighters[i]);
            }


        }
    }

    public IEnumerator EndBattle()
    {
        isBattleActive = false;
        battleUI.SetActive(false);
        enemyTargetPanel.SetActive(false);
        // notice here
        actionMenu.SetActive(false);
        magicPanel.SetActive(false);
        yield return new WaitForSeconds(3.5f);
        foreach (Fighters playersLeft in activeFighters)
        {
            if (playersLeft.fighterData.isPlayer)
            {
                foreach (PlayerStats playerstats in GameManager.Instance.GetPlayers())
                {
                    if (playersLeft.fighterData.fighterName == playerstats.playerName)
                    {
                        playerstats.currentHP = playersLeft.fighterData.health;
                        playerstats.currentMP = playersLeft.fighterData.mana;
                    }

                }
            }
            Destroy(playersLeft.gameObject);
        }
        activeFighters.Clear();
        currentTurnIndex = 0;
        isSummon = false;
        GameManager.Instance.isActive = false;
        SceneManager.LoadScene(5);


    }

    public void Run()
    {
        if (Random.value > chance)
        {

            canRun = true;
            StartCoroutine(EndBattle());
            // UIManager.Instance.FadeInBlack();


        }
        else
        {
            canRun = false;
            NextTurn();
            chance += .05f;
            print("No escaping for you!");
        }

    }

    private IEnumerator ExitBattle()
    {
        GameManager.Instance.isActive = false;

        isBattleActive = false;
        while (wait >= 0f)
        {
            wait -= Time.deltaTime;
            yield return null;
        }
        UIManager.Instance.FadeOutBlack();

        SceneManager.LoadScene(2);

        LevelCharacter.Instance.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        battleUI.SetActive(false);
        isSummon = false;
        wait = 0.0f;
    }

    private void ResetChance()
    {
        if (chance == 1.0f)
        {

            StartCoroutine(ExitBattle());

        }
        chance = .25f;
    }
}
[System.Serializable]
public class BattleMoves
{

    public string moveAttackName;
    public int movePower;
    public int manaCost;

    public GameObject effect;

    public enum BattleMoveType { physical, magic }

    public BattleMoveType current;




}




