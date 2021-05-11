using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  public int Health;
  public int MaxHealth;
  public int Stamina;
  public int MaxStamina;
  public int Attack;
  // public int
    // Start is called before the first frame update
    void Start()
    {
      Attack = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if (Health > MaxHealth)
      {
        Health = MaxHealth;
      }   
      if (Stamina > MaxStamina)
      {
        Stamina = MaxStamina;
      }  
    }
    void LateUpdate()
    {

    }
}
