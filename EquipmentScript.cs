using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentScript : MonoBehaviour
{
    // public ItemCard weapon;
    public ItemCard head;
    public ItemCard chest;
    public ItemCard accessory;
    public ItemCard weapon;
    public GameObject PlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void equip(ItemCard item)
    {
      Debug.Log("ITEM TYPE HERE: " + item.getItemType());
      if (item.getItemType() == "Chest")
      {
        if (!(chest))
        {
          PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth += item.MaxHealthBonus;
          PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina += item.MaxStaminaBonus;

          chest = item;

        } 
        else
        {

          PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth -= chest.MaxHealthBonus;
          PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth += item.MaxHealthBonus;
          PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina -= chest.MaxStaminaBonus;
          PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina += item.MaxStaminaBonus;

          chest = item;

        }
      }

      if (item.getItemType() == "Head")
      {
        if (!(head))
        {
          PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth += item.MaxHealthBonus;
          PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina += item.MaxStaminaBonus;

          head = item;

        } 
        else
        {

          PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth -= head.MaxHealthBonus;
          PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth += item.MaxHealthBonus;
          PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina -= head.MaxStaminaBonus;
          PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina += item.MaxStaminaBonus;

          head = item;

        }
      }

      if (item.getItemType() == "Weapon")
      {
        PlayerStats.transform.GetComponent<PlayerStats>().Attack = item.AttackBonus;
        weapon = item;
      }


    }
    public void clearAll()
    {
      if (head){
        PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth -= head.MaxHealthBonus;
        PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina -= head.MaxStaminaBonus;
        head = null; 
      }
      if (chest){
        PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth -= chest.MaxHealthBonus;
        PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina -= chest.MaxStaminaBonus;
        chest = null; 
      }
      if (accessory){
        accessory = null; 
      }
      if (weapon){
      PlayerStats.transform.GetComponent<PlayerStats>().Attack = 0;
      weapon = null; 
      }
    }
}
