using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public bool unlocked = true;
    public Card[] EnvChild;

    public bool findLoot;
    public bool UniqueBehavior;
    public string ScriptName;
    public int lootToFind = 1;
    public Rarity itemRarity;

    [Header("Base Settings")]
    [Space(10)]
    
    [@TextAreaAttribute(5,10)]
    [SerializeField] string gameText;
    [SerializeField] string option1;
    [SerializeField] string option2;

    // [SerializeField] List<string> parties = new List<string>();

    // [SerializeField] string cardTitle;
    [SerializeField] Color textColor;




    [SerializeField] public Card[] otherCards;
    
    [Space(15)]
    [Header("Randomize Settings")]
    [Space(30)]
    public bool randomizeFirst;
    public Card[] randomPickFirst;

    public bool randomizeSecond;
    public Card[] randomPickSecond;

    [Space(15)]
    [Header("Fight Settings")]
    [Space(30)]

    public bool FirstChoiceFight;
    public bool SecondChoiceFight;

    public Card Goodoutcome;
    public Card Badoutcome;

    public EnemyCard Enemy;

    public string getCardText()
    {
      return gameText;
    }

    public string getUniqueScript()
    {
      return ScriptName;
    }
    

    public string getOption1()
    {
      return option1;
    }

    public string getOption2()
    {
      return option2;
    }
    // public string getCardTitle()
    // {
    //   return cardTitle;
    // }


    public Color getCardColor()
    {
      return textColor;
    }

    // Update is called once per frame
    public Card[] getOtherCards()
    {
      // Debug.Log(Se);
        return otherCards;
    }
    public Card getRandomCard(int index)
    {
      // Debug.Log(Se);
      if (index == 0){
        // Card[] unlockedCards = randomPickFirst;
        List<Card> unlockedCards = new List<Card>();
        for (var i = 0; i < randomPickFirst.Length; i++){
          if (randomPickFirst[i].unlocked){
            Debug.Log(randomPickFirst[i].name + "Is Unlocked");
            unlockedCards.Add(randomPickFirst[i]);
          }else{
            Debug.Log(randomPickFirst[i].name + "Is Locked");
          }

        }
        Debug.Log("CURRENTLY ON: " + this.name);
        Debug.Log("FULL STRING OF UNLOCKED: " + unlockedCards);

        var picked = unlockedCards[Random.Range(0, unlockedCards.Count)];
        for (var e = 0; e < 5; e++){
          Debug.Log(Random.Range(0, 1));
        }
        Debug.Log("HOW MANY UNLOCKED: " + unlockedCards.Count);
        // Debug.Log("ENV CARD TO SHOW: " + unlockedCards[Random.Range(0, unlockedCards.Count + 1)]);


        // if (picked.Unlocked){
        //   Debug.Log("ITS UNLOCKED");
        // }else{
        //   Debug.Log("ITS LOCKED");
        // }
        return picked;
      }
      else{
        return randomPickSecond[Random.Range(0, 2)];
      }

    }
}
