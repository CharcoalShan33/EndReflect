using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // manage various items, menus, conditions/win or losing, player status
    public static GameManager Instance;
    public bool Active;

    PlayerData[] players;

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
        players = FindObjectsOfType<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {
            PlayerController.instance.DeactivateMovement(true);
        }
        else
        {
            PlayerController.instance.DeactivateMovement(false);
        }
    }
    public PlayerData[] GetPlayers()
    {
        return players;
    }
}
