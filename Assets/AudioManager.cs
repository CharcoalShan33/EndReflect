using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance;

    private AudioSource audioSource;

    private AudioClip playClip;

    // Start is called before the first frame update
    void  Awake()
    {
       if(_instance != this && _instance != null )
       {
            Destroy(gameObject);
       }

       DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
