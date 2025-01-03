using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public string transitionAreaName;
    // Start is called before the first frame update
    void Start()
    {
        if(transitionAreaName == LevelCharacter.Instance.sceneName)
        {
            LevelCharacter.Instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}