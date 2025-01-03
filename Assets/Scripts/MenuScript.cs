using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuScript : MonoBehaviour
{
    //[SerializeField] bool haveSaveFile;
    //[SerializeField] GameObject continueButton;
    // Start is called before the first frame update

    public void NewGame(string newGame)
    {

        SceneManager.LoadScene(newGame);
    }

    public void Quit()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }

    }
    public void Continue()
    {

    }

    public void Options()
    {
        
    }
    public void Credits(int index)
    {



        SceneManager.LoadScene(index);

    }
    public void BackButton(int index)
    {
        
        SceneManager.LoadScene(index);


    }
}
