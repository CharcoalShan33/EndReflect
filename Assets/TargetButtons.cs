using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetButtons : MonoBehaviour
{
    public string moveName;
    public int activeBattleTarget;
    public TextMeshProUGUI targetName;
    // Start is called before the first frame update
    void Start()
    {
        targetName = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void PressButton()
    {
        BattleMachine.Instance.PlayerAttacking(moveName, activeBattleTarget);
    }
}
