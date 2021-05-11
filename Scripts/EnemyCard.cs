using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "EnemyCard")]
public class EnemyCard : ScriptableObject
{
    // [@TextAreaAttribute(5,10)]
    // [SerializeField] string ItemDescription;
    // [SerializeField] string option1;
    [SerializeField] int HP;
    [SerializeField] int Stamina;

    public Sprite newimage;
   

    public int getEnemyHP()
    {
      return HP;
    }
    public int getEnemyStamina()
    {
      return Stamina;
    }

    public Sprite getSprite()
    {
      return newimage;
    }

    public int setEnemyHP(int newHP)
    {
      return newHP;
    }
    // public int getEnemyStamina()
    // {
    //   return Stamina;
    // }
    // public string getEnemyName()
    // {
    //   return EnemyCard.name;
    // }

}
