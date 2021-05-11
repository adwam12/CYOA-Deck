using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateStatsUI : MonoBehaviour
{
  public GameObject PlayerStatsScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate() 
    {
      // Debug.Log(PlayerStatsScript.transform.GetComponent<PlayerStats>().Health);
      gameObject.transform.GetChild(0).GetComponent<Text>().text = "HP: " + PlayerStatsScript.transform.GetComponent<PlayerStats>().Health + "/" + PlayerStatsScript.transform.GetComponent<PlayerStats>().MaxHealth;
      gameObject.transform.GetChild(1).GetComponent<Text>().text = "STA: " + PlayerStatsScript.transform.GetComponent<PlayerStats>().Stamina + "/" + PlayerStatsScript.transform.GetComponent<PlayerStats>().MaxStamina;
      gameObject.transform.GetChild(2).GetComponent<Text>().text = "Head: " + PlayerStatsScript.transform.GetComponent<EquipmentScript>().head;
      gameObject.transform.GetChild(3).GetComponent<Text>().text = "Chest: " + PlayerStatsScript.transform.GetComponent<EquipmentScript>().chest;
      gameObject.transform.GetChild(4).GetComponent<Text>().text = "Accessory: " + PlayerStatsScript.transform.GetComponent<EquipmentScript>().accessory;
      gameObject.transform.GetChild(5).GetComponent<Text>().text = "Weapon: " + PlayerStatsScript.transform.GetComponent<EquipmentScript>().weapon;





    }
}
