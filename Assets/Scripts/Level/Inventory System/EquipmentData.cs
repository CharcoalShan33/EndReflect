using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EquipmentType
{
    Sword,
    Armor,
    Scroll,
    Bow,
    Staff,
    Amulet,


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

    /// <summary>
    ///  add elements later
    /// </summary>




    public void AddModifiers()
    {
        CharacterStats charStats = LevelCharacter.Instance.characterData;

        //charStats.armorPower += defensePower;
        //charStats.weaponPower += attackPower;
        //charStats.defense += defense;
        //charStats.speed += agilitiy;
        //charStats.attack += strength;
        //charStats.magic += intelligence;
        //charStats.magicDefense = resistance;
        //charStats.maxHP += health;
        //charStats.MaxMP += mana;


    }

}
