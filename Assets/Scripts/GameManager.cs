using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // manage various items, menus(open/closing, updating), conditions/win or losing, player status
    public static GameManager Instance;
    static bool Active;

    CharacterStats[] players;
    BattleStats[] battleData;

    //static float enemyStatsMultiplier; // for Battle
    //static float enemyBattleLevelStats// for battle

    static bool didWin;
   

    //[SerializeField] GameObject HUD, shopMenu, craftMenu, inventoryMenu;
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
        players = FindObjectsOfType<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {
           // PlayerController.instance.DeactivateMovement(true);
        }
        else
        {
            //PlayerController.instance.DeactivateMovement(false);
        }
        //switch(currentDifficulty)
    }
    public CharacterStats[] GetPlayers()
    {
        return players;
    }

    public bool WinLose(bool choice)
    {
        didWin = choice;
        if(didWin)
        {
            //gain Friendship
            //gain Sanity Meter


        }
        else
        {
        //decrease sanity meter
        // restore healt to one
        //  if sanity meter is zero and player is dead
        // GameOver
        }
        return choice;
    }
     void GameOver()
    {
        // show gameover screen
        // go back to main menu
        // possibly hit continue

    }

    
}
