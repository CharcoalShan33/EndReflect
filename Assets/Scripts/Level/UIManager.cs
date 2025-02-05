using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using UnityEngine.InputSystem;
using System.Security.Cryptography.X509Certificates;
using System;
using UnityEngine.Audio;


public class UIManager : MonoBehaviour
{

    //ShakeManager shaker;
  
    public static UIManager Instance;
    


    [Header("Character Information")] // at the top for selection

    PlayerStats[] playerInfo;
    [SerializeField] GameObject[] characterPanel;
    [SerializeField] TextMeshProUGUI[] nameText;

    [SerializeField] TextMeshProUGUI[] healthText;
    [SerializeField] TextMeshProUGUI[] manaText;

    [SerializeField] TextMeshProUGUI[] maxHealthText;
    [SerializeField] TextMeshProUGUI[] maxManaText;
    [SerializeField] TextMeshProUGUI[] lvlText;
    [SerializeField] TextMeshProUGUI[] currentExpText;
    [SerializeField] Slider[] xpSlider;
    
    [SerializeField] Image[] characterImages;
    
    
    [Header("Pause Menu")]





    [Header("Options Menu")]

    public Slider bgSlider;
    public Slider sfxSlider;

    public Slider brightnessSlider;

    public string parameter;
    [SerializeField] AudioMixer audioMix;
    [SerializeField] float multiplier;


    [Header("Sanity UI")]

    [SerializeField] Slider sanitySlider;
    [SerializeField] TextMeshProUGUI friendText;
    
   
    [Header("Full Status")]
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] TextMeshProUGUI statMATK;
    [SerializeField] TextMeshProUGUI statSPD;
    [SerializeField] TextMeshProUGUI statATK;
    [SerializeField] TextMeshProUGUI statDEF;
    [SerializeField] TextMeshProUGUI statMDEF;
    
    [SerializeField] TextMeshProUGUI statMagicPower;
    [SerializeField] TextMeshProUGUI statAttackPower;
    [SerializeField] TextMeshProUGUI statArmorDefense;
    [SerializeField] TextMeshProUGUI statMagicDefense;


    [SerializeField] GameObject[] statsButtons;

    

    [Header("Fading")]
    [SerializeField] Image fadeScreen;

    [Range(0,5)]
    [SerializeField] float fadeSpeed = 1.0f;

    private IEnumerator fadingRoutine;


    [Header("Other")]
    [SerializeField] GameObject menu;// whole menu.    
    [SerializeField] GameObject characterSelectMenu;

    void Awake()
    {
     if(Instance != null && Instance != this)
     {
        Destroy(gameObject);
     }
     else
     {
        Instance = this;
     }
    }

    private void Start()
     {
        DontDestroyOnLoad(gameObject);
      
    }
    void Update()
    {
        if(Keyboard.current.mKey.wasPressedThisFrame)
        {
            Open();
            UpdatePlayerStats();
        }
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Close();
        }
    }

    private void Close()
    {
        menu.SetActive(false);
    }

    private void Open()
    {
        menu.SetActive(true);
    }

    // Start is called before the first frame update

    public void FadeInBlack()
    {
        if(fadingRoutine != null)
        {

        StopCoroutine(fadingRoutine);
        }
        fadingRoutine = FadeRoutine(1f);
        StartCoroutine(fadingRoutine);
    }
    public void FadeOutBlack()
    {
         if(fadingRoutine != null)
        {

            StopCoroutine(fadingRoutine);
        }
        fadingRoutine = FadeRoutine(0f);
        StartCoroutine(fadingRoutine);

    }

    public void FadeInWhite()
    {
        
         if(fadingRoutine != null)
        {

        StopCoroutine(fadingRoutine);
        }
        fadingRoutine = FadeWhiteRoutine(1f);
        StartCoroutine(fadingRoutine);

    }

    public void FadeOutWhite()
    {

         if(fadingRoutine != null)
        {

        StopCoroutine(fadingRoutine);
        }
        fadingRoutine = FadeWhiteRoutine(0f);
        StartCoroutine(fadingRoutine);
    }
    

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        while(!Mathf.Approximately(fadeScreen.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeScreen.color = new(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,alpha );
            yield return null;
        }
    }
    private IEnumerator FadeWhiteRoutine(float targetAlpha)
    {

         while(!Mathf.Approximately(fadeScreen.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeScreen.color = new(1, 1, 1,alpha );
            yield return null;
        }
    }

    public void SliderValueForVolume()
    {
        //audioMix.SetFloat("BG_Music", )
    }


    public void StatusButtons()
    {
        for(int i = 0; i < statsButtons.Length; i++)
        {
            statsButtons[i].SetActive(true);

            statsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerInfo[i].playerName;


        }
        UpdateFullStatus(0);
    }

    public void UpdatePlayerStats()
    {
       playerInfo = GameManager.Instance.GetPlayers();
       for(int i = 0; i < playerInfo.Length; i++)
        {

            characterPanel[i].SetActive(true);

            nameText[i].text = playerInfo[i].playerName;

            healthText[i].text = playerInfo[i].currentHP.ToString();
            manaText[i].text = playerInfo[i].currentMP.ToString();
            maxHealthText[i].text = playerInfo[i].maxHP.ToString();

            maxManaText[i].text = playerInfo[i].MaxMP.ToString();

            maxManaText[i].text = playerInfo[i].MaxMP.ToString();
            currentExpText[i].text = playerInfo[i].currentXP.ToString();
            lvlText[i].text = playerInfo[i].playerLevel.ToString();


            xpSlider[i].maxValue = playerInfo[i].expToNextLevel[playerInfo[i].playerLevel];
            xpSlider[i].value = playerInfo[i].currentXP;

            characterImages[i].sprite = playerInfo[i].characterImage;


            

        }
    }

    public void UpdateFullStatus(int playerNumber)
    {
        PlayerStats playerSelected = playerInfo[playerNumber];
       
        statMATK.text = playerSelected.magic.ToString();

        statSPD.text = playerSelected.speed.ToString();

        statATK.text = playerSelected.attack.ToString();

        statDEF.text = playerSelected.defense.ToString();

        statMDEF.text = playerSelected.magicDefense.ToString();
        // icon Here

        
        
    }
}

