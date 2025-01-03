using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.Android;


public class BattleMachine : MonoBehaviour
{
    /// <summary>
    /// This is for the Course with "Jimmy and them"
    /// </summary>
    [Header("Positions")]
    [SerializeField] Transform[] playerPositions;
    [SerializeField] Transform[] enemyPositions;

    [Header("Battle Player Information UI")]
    [SerializeField] GameObject[] characterInfoPanels;
    [SerializeField] List<GameObject> enemyInfoPanels;

    [SerializeField] TextMeshProUGUI playerHP;
    [SerializeField]  TextMeshProUGUI enemyHP;
    [SerializeField] TextMeshProUGUI playerMaxHP;
    [SerializeField]  TextMeshProUGUI enemyMaxHP;

    [SerializeField] TextMeshProUGUI playerMP;
    [SerializeField]  TextMeshProUGUI enemyMP;

    [SerializeField] TextMeshProUGUI playerMaxMP;
    [SerializeField]  TextMeshProUGUI enemyMaxMP;

    

    [Header("Character Battle Panels")]
    [SerializeField] GameObject enemyTargetPanel;
    [SerializeField] GameObject actionMenu;
    [SerializeField] Button[] enemyButtons;

    [SerializeField] GameObject magicPanel;
    [SerializeField] Button[] magicButtons;

    [Header("Other Battle UI")]
    [SerializeField] GameObject actionPanel;
    [SerializeField] TextMeshProUGUI actionText;

    [Header("Battle")]
    [SerializeField] int currentTurnIndex;
    [SerializeField] List<Fighters> activeFighters;
    [SerializeField] List<Fighters> enemyFighters;
    [SerializeField] List<Fighters> playerFighters;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
