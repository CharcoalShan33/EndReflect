using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public static UIManager Instance;

    [SerializeField] Image fadeImage;

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


    void Start()
    {
        // if (Instance != null && Instance != this)
        //{
        // Destroy(gameObject);
        //}
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {

    }

}
