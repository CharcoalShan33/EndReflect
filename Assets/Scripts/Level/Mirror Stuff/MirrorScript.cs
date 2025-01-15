using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    //SpriteRenderer spr;
    SpriteRenderer characterRender;

    

    

    

    // Start is called before the first frame update
    void Start()
    {
        //spr = GetComponent<SpriteRenderer>();
        characterRender = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// lerp alpha to show character
    /// </summary>
    /// <param name="character"></param>
    public void ShowCharacter(Sprite character)
    {

        characterRender.sprite = character;
        
    }
}
