using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.EventSystems;

public class UI_EquipmentSlot : UI_Slot
{
    public EquipmentType equipSlotType;
  
 
    private void OnValidate()
    {
       gameObject.name = "Equipment slot - " + equipSlotType.ToString();
        
    }
     public override void OnPointerDown(PointerEventData eventData)
    {
        Inventory.instance.UnequipItem(item.data as EquipmentData);
        Inventory.instance.AddItem(item.data as EquipmentData);


        CleanUp();
    }
}
