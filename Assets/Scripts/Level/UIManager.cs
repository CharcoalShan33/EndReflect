using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
  
    public static UIManager Instance;
    
       

    [Header("Character Information")] // at the top for selection
    [SerializeField] GameObject[] characterPanel;
    [SerializeField] TextMeshProUGUI[] nameText;

    [SerializeField] TextMeshProUGUI[] healthText;
    [SerializeField] TextMeshProUGUI[] manaText;

    [SerializeField] TextMeshProUGUI[] maxHealthText;
    [SerializeField] TextMeshProUGUI[] maxManaText;
    [SerializeField] TextMeshProUGUI[] lvlText;
    [SerializeField] TextMeshProUGUI[] totalRequiredXp;
    [SerializeField] Slider[] xpSlider;
    
    [SerializeField] Image[] characterImages;
    

    //[Header("Character Status")]
    //[SerializeField] GameObject[] characterWindows;
    // detailed selection
    // [SerializeField] GameObject[] statsButton;
    //[SerializeField] TextMeshProUGUI[] statName;
    //[SerializeField] TextMeshProUGUI statHP;
    //[SerializeField] TextMeshProUGUI statMP;
    // [SerializeField] TextMeshProUGUI statMAG;
    // [SerializeField] TextMeshProUGUI statSPD;
    // [SerializeField] TextMeshProUGUI statATK;
    // [SerializeField] TextMeshProUGUI statDEF;
    //[SerializeField] TextMeshProUGUI StatMDEF;
    //[SerializeField] Image characterIcon;

    [SerializeField] Image fadeScreen;

    [Range(0,5)]
    [SerializeField] float fadeSpeed = 1.0f;

    private IEnumerator fadingRoutine;

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
   
}