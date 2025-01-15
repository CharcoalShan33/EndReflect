using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.UIElements;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance;



    [Header("Background Music")]
    [SerializeField]
    private AudioSource[] bgm;


    [Header("Sound Effects")]
    [SerializeField]
    private AudioSource[] sfx;

    public bool playBGMusic;
    private int musicIndex;

    // Start is called before the first frame update
    void  Awake()
    {
       if(_instance != this && _instance != null )
       {
            Destroy(gameObject);
       }
       else
       {
        _instance = this;
       }

      
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if(!playBGMusic)
        {
            StopBGM();
        }
        else
        {
            if(!bgm[musicIndex].isPlaying)
            {
                PlayBackgroundMusic(musicIndex);
            }
        }
    }

    public void PlaySFXClip(int sfxClip)
    {
        if(sfxClip < sfx.Length)
        {
            sfx[sfxClip].pitch = Random.Range(.75f,1.5f);
            sfx[sfxClip].Play();
        }
       // playclip at point 
       // point at animation
        //audioSource.PlayOneShot(playSFXClip[0]);
    }
     public void PlayBackgroundMusic(int bmclip)
    {
       musicIndex = bmclip;
        StopBGM();
        bgm[musicIndex].Play();
    }

    public void StopBGM()
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
    public void StopSFX(int index)
    {
        if(sfx[index])
        {
            sfx[index].Stop();
        }
    }


}
