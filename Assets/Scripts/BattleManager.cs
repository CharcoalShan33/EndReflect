using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{

    private bool isBattleActive;
    [SerializeField] int sceneNumber;
    [SerializeField] GameObject scene;
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
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartBattle();//new[]{"Dominic","Paul","Zena"});
        }
        //StartBattle(new string[]{"Paul","Dominic","Zena"});

    }
    public void StartBattle()//string[] enemies)
    {

        Preparing();


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
}
