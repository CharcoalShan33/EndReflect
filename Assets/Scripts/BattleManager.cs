using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    private bool isBattleActive;
    public  int sceneNumber;
   [SerializeField] Transform[] playerPositions, enemyPositions;

    [SerializeField] BattleCharacters[] players, enemies;


    //[SerializeField] BattleCharacters defaultPlayer;


    // Start is called before the first frame update

    private void Start()

    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame

    private void Update()
    {
    if(Keyboard.current.bKey.isPressed)
       {
        StartBattle();
        //StartBattle(new string[]{"Paul","Dominic","Zena"});
       } 
    }

   private void StartBattle()
    {
        if(!isBattleActive)
        {
            isBattleActive = true;
            GameManager.Instance.Active = true;
            SceneManager.LoadScene(sceneNumber);
            PlayerController.instance.gameObject.SetActive(false);
        }

    }

}
