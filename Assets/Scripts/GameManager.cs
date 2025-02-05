using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // manage various items, menus(open/closing, updating), conditions/win or losing, player status
    public static GameManager Instance;
    public  bool isActive;

    //CharacterStats[] players;
    [SerializeField] PlayerStats[] playerStats;

    LevelCharacter activeCharacter;


    [SerializeField] GameObject levelPanel;
    
    //static float enemyStatsMultiplier; // for Battle
    //static float enemyBattleLevelStats// for battle

   public bool didWin;
   

    [SerializeField] bool HUDOpen;
   // [SerializeField] bool shopMenuOpen;
   // [SerializeField] bool craftMenuOpen;
    [SerializeField] bool inventoryMenuOpen;
    // public Enum Difficulty { Easy, Medium, Hard, };
    // private Difficulty currentDifficulty
    //enum for rarity
    // private int currentSanity // battle boost, rarer drops

    [SerializeField] bool menuOpen;

    [Header("Exp Window")]
    [SerializeField] int giveXP;
    [SerializeField] TextMeshProUGUI xpText;
    [SerializeField] TextMeshProUGUI itemText;
    [SerializeField] GameObject window;

   [ SerializeField] ConsumableData[] itemsToGet;
   // [[SerializeField]


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
        activeCharacter = FindObjectOfType<LevelCharacter>();
      
        playerStats = FindObjectsOfType<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive || menuOpen)
        {
            LevelCharacter.Instance.DeactivateMovement(true);
        }
        else
        {
            LevelCharacter.Instance.DeactivateMovement(false);
        }
        //switch(currentDifficulty)


        if(didWin)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }
    public PlayerStats[] GetPlayers()
    {
        return playerStats;
    }

    private void Win()
    {

        didWin = true;
       
        //gain Friendship
        //gain Sanity Meter
        
    }

    private void Lose()
    {
        didWin = false;
        //decrease sanity meter
        // restore health to one
        //  if sanity meter is zero and player is dead
        // GameOver

        
    }
   public void GameOver()
    {
       UIManager.Instance.FadeInBlack();



        // show gameover screen
        // go back to main menu
        // possibly hit continue

    }

    public void LevelUp()
    {
        levelPanel.SetActive(true);
    }

    public void AddExp(int amount)
    {

    }

    public void OpenRewardsScreen(int xpEarned, ConsumableData[] recieveItems )
    {


        giveXP = xpEarned;
        itemsToGet = recieveItems;
        xpText.text = string.Empty;


        foreach(ConsumableData rewardItems in itemsToGet)
        {

            itemText.text += rewardItems;

        }
    window.SetActive(true);

    }

    public void CloseBattleRewardsMenu()
    {

        foreach(PlayerStats activePlayer in GetPlayers())
        {

            if(activePlayer.gameObject.activeInHierarchy)
            {
                AddExp(giveXP);
            }
        }
    foreach(ConsumableData items in itemsToGet)
        {
            Inventory.instance.AddItem(items);
        }

        window.SetActive(false);
        isActive = false;
    }


}
