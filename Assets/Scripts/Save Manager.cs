using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    // Game Data 

    public GameData data;


    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {

        data = new GameData();


    }

    public void LoadGame()
    {

    if(data == null)
    {
        Debug.Log("No Save Data");
        NewGame();
    }



    }

    public void SaveGame()
    {
        
    }


}
