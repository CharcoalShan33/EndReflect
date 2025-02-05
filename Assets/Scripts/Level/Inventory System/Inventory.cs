using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;


    public List<Item> inventoryItem = new();
    public Dictionary<ItemData, Item> inventoryDictionary;
    // dictonary holds a value and store them in a custom ID/label.

    public List<Item> materialItem = new();
    public Dictionary<ItemData, Item> materialDictionary;
    // dictonary holds a value and store them in a custom ID/label.


    public List<Item> equipmentItem = new();
    public Dictionary<EquipmentData, Item> equipmentDictionary;
    // dictonary holds a value and store them in a custom ID/label.





    [Header("Inventory UI")]
    [SerializeField] private Transform inventorySlotParent;
    [SerializeField] private Transform stashSlotParent;
    [SerializeField] private Transform equipParent;


    private UI_Slot[] inventoryItemSlot;
    // materials
    private UI_Slot[] materialItemSlot;

    private UI_EquipmentSlot[] equipSlot;

   
    [SerializeField] Transform dropPosition;
    public TextMeshProUGUI selectItemName, selectedItemDescription;
    public GameObject useButton, discardButton, equipButton, unequipButton;

    [Range(1,4)]
    private int equipNum;
    [SerializeField] GameObject inventoryPanel;
    // remove items, drop position.


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        inventoryItem = new List<Item>();
        inventoryDictionary = new Dictionary<ItemData, Item>();
        inventoryItemSlot = inventorySlotParent.GetComponentsInChildren<UI_Slot>();

        
        materialItem = new List<Item>();
        materialDictionary = new Dictionary<ItemData, Item>();
        materialItemSlot = stashSlotParent.GetComponentsInChildren<UI_Slot>();

        equipmentItem = new List<Item>();
        equipmentDictionary = new Dictionary<EquipmentData, Item>();
        equipSlot = equipParent.GetComponentsInChildren<UI_EquipmentSlot>();


       
    }

    public void EquipItem(ItemData _item)
    {
        
        EquipmentData newEquip = _item as EquipmentData;
        Item newItem = new Item(newEquip);
    
        EquipmentData OldItem = null;
        foreach (KeyValuePair<EquipmentData, Item> items in equipmentDictionary) // or equipmentdata in item list
        {
            if (items.Key.equipType == newEquip.equipType)
            {
                OldItem = items.Key;
            }
        }
        if (OldItem != null)
        {
            UnequipItem(OldItem);
            AddItem(OldItem);
        }
        
    equipmentItem.Add(newItem);
    equipmentDictionary.Add(newEquip, newItem); // saving the data and object.
      


        RemoveItem(_item);
        
        UpdateSlotUI();

    }

    public void UnequipItem(EquipmentData RemoveItem)
    {
        if (equipmentDictionary.TryGetValue(RemoveItem, out Item _itemValue))
        {
            equipmentItem.Remove(_itemValue);
            equipmentDictionary.Remove(RemoveItem);
         
        }
    }

    public void AddItem(ItemData _item)
    {
        if (_item.type == ItemType.Equipment)
        {
            AddToInventory(_item);
        }
        else if (_item.type == ItemType.Resource)
        {
            AddToMaterials(_item);
        }

        UpdateSlotUI();
    }

    private void AddToMaterials(ItemData _item)
    {
        if (materialDictionary.TryGetValue(_item, out Item value))
        {
            value.AddStack();
        }
        else
        {
            // we add the item to the list and dictionary.
            Item newMaterial = new(_item); // create new item
            materialItem.Add(newMaterial); // add the item to item list
            materialDictionary.Add(_item, newMaterial); // store the value/identifier of the item
        }
    }

    private void AddToInventory(ItemData _item)
    {
        //if there is an item avaliable, then add to the stack
        if (inventoryDictionary.TryGetValue(_item, out Item value))
        {
            value.AddStack();
        }
        else
        {
            // we add the item to the list and dictionary.
            Item newItem = new(_item); // create new item
            inventoryItem.Add(newItem); // add the item to item list
            inventoryDictionary.Add(_item, newItem); // store the value/identifier of the item


        }

    }

    private void UpdateSlotUI()
    {
        for (int i = 0; i < equipSlot.Length; i++)
        {
            // taking each slot, comparing if the item is in the set dictionary, if so, update the value.

            foreach (KeyValuePair<EquipmentData, Item> items in equipmentDictionary) // or equipmentdata in item list
            {
                if (items.Key.equipType == equipSlot[i].equipSlotType)
                {
                    equipSlot[i].UpdateSlot(items.Value);
                }
            }

        }

        for (int i = 0; i < inventoryItemSlot.Length; i++)
        {

            inventoryItemSlot[i].CleanUp();
        }
        for (int i = 0; i < materialItemSlot.Length; i++)
        {

            materialItemSlot[i].CleanUp();
        }




        for (int i = 0; i < inventoryItem.Count; i++)
        {

            inventoryItemSlot[i].UpdateSlot(inventoryItem[i]);


        }
        for (int i = 0; i < materialItem.Count; i++)
        {

            materialItemSlot[i].UpdateSlot(materialItem[i]);


        }

    }
    public void RemoveItem(ItemData _item)
    {
        if (inventoryDictionary.TryGetValue(_item, out Item value))
        {
            if (value.stackAmount <= 1)
            {
                inventoryDictionary.Remove(_item);// removeing the data 
                inventoryItem.Remove(value); // removing the item.
            }
            else
            {
                value.RemoveStack();
            }
        }

        if (materialDictionary.TryGetValue(_item, out Item material))
        {
            if (material.stackAmount <= 1)
            {
                materialItem.Remove(material);
                materialDictionary.Remove(_item);
            }
            else
            {
                material.RemoveStack();
            }

        }
        UpdateSlotUI();

        
    }

    
}
