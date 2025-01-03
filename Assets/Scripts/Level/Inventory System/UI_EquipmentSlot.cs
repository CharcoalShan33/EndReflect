using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.U2D.IK;

public class UI_EquipmentSlot : UI_Slot
{
    public EquipmentType equipSlotType;
    public int equipId;
    private bool isDuplicate;

    private List<UI_EquipmentSlot> equipList = new();
    void OnValidate()
    {
        gameObject.name = equipSlotType.ToString();
        equipList.Add(this);
        
    }
    private void Start()
    {
        
    
        switch(equipId)
        {
            case 0:
            equipSlotType = EquipmentType.Sword;
            gameObject.name = equipSlotType.ToString();

            break;

            case 1:
            equipSlotType = EquipmentType.Bow;
             gameObject.name = equipSlotType.ToString();
            
            break;

            case 2: 
            equipSlotType = EquipmentType.Staff;
             gameObject.name = equipSlotType.ToString();
            break;

            case 3:
            equipSlotType = EquipmentType.Armor;
             gameObject.name = equipSlotType.ToString();
            break;

            case 4:
            equipSlotType = EquipmentType.Scroll;
             gameObject.name = equipSlotType.ToString();
            break;
            case 5:
            equipSlotType = EquipmentType.Amulet;
             gameObject.name = equipSlotType.ToString();
            break;
        }
    }
   
   private void SwitchItem()
   {
    
    var c1 = equipList[equipId];
    var c2 = equipList[equipId];

    if(c1.equipId.Equals(c2.equipId))
    {

        isDuplicate = true;
      

    }


   }
}
