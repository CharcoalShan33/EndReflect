using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;


public enum EquipmentType
{
    Weapon,
    Armor,
    AccessoryOne,

    AccessoryTwo



}
[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Equipment")]

public class EquipmentData : ItemData
{

    public EquipmentType equipType;

    [Header("Major Stats")]
    public int strength;
    public int agilitiy;
    public int defense;
    public int intelligence; // magic attack
    public int resistance; // magic defense

    [Header("Equipment Stats")]
    public int attackPower;
    public int defensePower;

    public int health;
    public int mana;

    public float damageModifier;

    /// <summary>
    ///  add elements later
    /// </summary>



    public void Start()
    {
        
    }


    public void AddModifiers()
    {


    }

    public void Modifiers()
    {
        CharacterStats newStats = LevelCharacter.Instance.GetComponent<CharacterStats>();
        // newStats.Attack += strength;
        //newStats.Defense += defense;
        newStats.attack.AddModifier(strength + attackPower);
        newStats.defense.AddModifier(defense);
        //newStats.speed.AddModifier(agilitiy);
        //newStats.magic.AddModifier(intelligence);
        // newStats.magicDefense.AddModifier(resistance);
        // newStats.maxHP.AddModifier(health);
        //newStats.MaxMP.AddModifier(mana);
        //newStats.weaponPower.AddModifier(attackPower);
        //newStats.armorPower.AddModifier(defensePower);
    }
    public void RemoveModifiers()
    {
        CharacterStats newStats = LevelCharacter.Instance.GetComponent<CharacterStats>();

        //newStats.Attack -= strength;
        //newStats.Defense -= defense;
        newStats.attack.RemoveModifier(strength - attackPower);
        newStats.defense.RemoveModifier(defense);
        //newStats.speed.RemoveModifier(agilitiy);
        //newStats.magic.RemoveModifier(intelligence);
        //newStats.magicDefense.RemoveModifier(resistance);
        //newStats.maxHP.RemoveModifier(health);
        //newStats.MaxMP.RemoveModifier(mana);
        // newStats.weaponPower.RemoveModifier(attackPower);
        //newStats.armorPower.RemoveModifier(defensePower);
    }

}
