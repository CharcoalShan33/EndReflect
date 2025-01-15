using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // manage various items, menus(open/closing, updating), conditions/win or losing, player status
    public static GameManager Instance;
    public  bool isActive;

    //CharacterStats[] players;
    BattleStats[] battleData;

    //static float enemyStatsMultiplier; // for Battle
    //static float enemyBattleLevelStats// for battle

   public bool didWin;
   

    [SerializeField] bool HUDOpen;
   // [SerializeField] bool shopMenuOpen;
   // [SerializeField] bool craftMenuOpen;
    [SerializeField] GameObject inventoryMenuOpen;
    // public Enum Difficulty { Easy, Medium, Hard, };
    // private Difficulty currentDifficulty
    //enum for rarity
    // private int currentSanity // battle boost, rarer drops

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
        //battleData = FindObjectsByType<Fighters>().;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive || HUDOpen || inventoryMenuOpen )
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
        else if(!didWin)
        {
            Lose();
        }
    }
    public BattleStats[] GetPlayers()
    {
        return battleData;
    }

    public void Win()
    {
        didWin = true;
       
        //gain Friendship
        //gain Sanity Meter
        
    }

    public void Lose()
    {
        didWin = false;
        //decrease sanity meter
        // restore health to one
        //  if sanity meter is zero and player is dead
        // GameOver
        
    }
     public  void GameOver()
    {
       
        // show gameover screen
        // go back to main menu
        // possibly hit continue

    }
}
