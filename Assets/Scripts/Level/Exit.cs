using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    [SerializeField] string areaName; // name of the current area

    [SerializeField] Enter areaEnter;
    // Start is called before the first frame update

    void Awake()
    {
        areaEnter.transitionAreaName = areaName;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagManager.PLAYER_TAG))
        {
            LevelCharacter.Instance.sceneName = areaName;
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
