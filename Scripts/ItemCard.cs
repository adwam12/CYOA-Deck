using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipmentType { Head, Chest, Accessory, Weapon }
public enum Rarity { common, uncommon, rare, legendary, gold }


[CreateAssetMenu(menuName = "ItemCard")]

public class ItemCard : ScriptableObject
{
    [@TextAreaAttribute(5,10)]
    [SerializeField] string ItemDescription;
    [SerializeField] string option1;
     public bool usable;

    public bool healthUp;
    public Rarity itemRarity;


    public int IncreaseHealthBy;

    public bool staminaUp;

    public int IncreaseStaminaBy;

    public bool maxHealthUp;

    public int IncreaseMaxHealthBy;

    public Sprite newimage;

    [Header("Armor Settings:")]
    [Space(10)]

    public bool equipable;
    
    [Space(10)]
    // public bool head;
    // public bool chest;
    // public bool accessory;
    // public bool weapon;

    public EquipmentType itemType;

    
    public int MaxHealthBonus;
    public int MaxStaminaBonus;
    public int AttackBonus;

   

    public string getItemDesc()
    {
      return ItemDescription;
    }

    public Sprite getSprite()
    {
      return newimage;
    }

    public string getOption1()
    {
      return option1;
    }
    public string getItemType()
    {
      return itemType.ToString();
    }
}
