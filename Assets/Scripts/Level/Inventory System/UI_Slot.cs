using UnityEngine;
using Image = UnityEngine.UI.Image;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UI_Slot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemText;

    public Item item;

    // Start is called before the first frame update



    public void UpdateSlot(Item _newItem)
    {
        item = _newItem;
        itemImage.color = Color.white;
        if (item != null)
        {
            itemImage.sprite = item.data.icon;
            if (item.stackAmount > 1)
            {
                itemText.text = item.stackAmount.ToString();
            }
            else
            {
                itemText.text = string.Empty;
            }
        }
    }

    public void CleanUp()
    {

        item = null;
        itemImage.sprite = null;
        itemImage.color = Color.clear;
        itemText.text = string.Empty;


    }
 public void OnPointerDown(PointerEventData eventData)
    {
        OnImpact();
    }

     public void OnImpact()
    {   
        if(item == null)
            return;
        
    
       
        if(Input.GetKey(KeyCode.U))
        {
            Inventory.instance.RemoveItem(item.data);
            return;
        }
        else if (item.data.type == ItemType.Equipment)
        {
            Inventory.instance.EquipItem(item.data);
            
        }

    }

   
    public void OnSelected()
    {


    }
}
