using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagicAttackButtons : MonoBehaviour
{
    public string spellName;
    public int spellCost;

    public TextMeshProUGUI spellNameText;
    public TextMeshProUGUI spellCostText;

    public void PressMagicButton()
    {

        if(BattleMachine.Instance.GetActiveFighter().fighterData.mana >= spellCost)
        {
            
            BattleMachine.Instance.OpenMagicAttackMenu(false);
            BattleMachine.Instance.TargetMenu(spellName);
            BattleMachine.Instance.GetActiveFighter().fighterData.mana -= spellCost;


        }
        else
        {
            // BattleMachine.Instance.notifications.ActivateNotification();
            //BattleMachine.Instance.magicPanel.SetActive(false);
            //BattleMachine.Instance.notifications.SetText(" No mana to expend" );
        }

       
        
       
    }
    
}
