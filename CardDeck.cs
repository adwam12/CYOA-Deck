using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDeck : MonoBehaviour
{
  // public ItemCard[] chosenCards = new ItemCard[0];
  public List<ItemCard> chosenItemsCards = new List<ItemCard>();
  public List<Card> chosenEnvCards = new List<Card>();

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    // public void Awake() {
    //   DontDestroyOnLoad(gameObject);
    // }
    public bool addItemToDeck(ItemCard item){
      if (chosenItemsCards.Count == 0){
        Debug.Log("ADD FIRST ITEM");
        chosenItemsCards.Add(item);
        return true;
      }else{
      for (int i = 0; i < chosenItemsCards.Count; i++)
         {
             if (chosenItemsCards[i].name.Contains(item.name))
             {
                 chosenItemsCards.Remove(item);
                 Debug.Log("REMOVED: " + item.name);
                 return false;
             }
             else
             {
               
                 Debug.Log("not equal");
                //  return;
             }
         }
         Debug.Log("CARD NOT IN DECK");
         chosenItemsCards.Add(item);
         return true;
      }
    }

    public bool addCardToDeck(Card EnvCard){
      if (chosenEnvCards.Count == 0){
        Debug.Log("ADD FIRST ITEM");
        chosenEnvCards.Add(EnvCard);
        return true;
      }else{
      for (int i = 0; i < chosenEnvCards.Count; i++)
         {
             if (chosenEnvCards[i].name.Contains(EnvCard.name))
             {
                 chosenEnvCards.Remove(EnvCard);
                 Debug.Log("REMOVED: " + EnvCard.name);
                 return false;
             }
             else
             {
               
                 Debug.Log("not equal");
                //  return;
             }
         }
         Debug.Log("CARD NOT IN DECK");
         chosenEnvCards.Add(EnvCard);
         return true;
      }
    }

    // Update is called once per frame
    void LateUpdate()
    {
      Text itemCounter = gameObject.transform.GetChild(0).GetComponent<Text>();
       itemCounter.text = "Item Cards: "+ chosenItemsCards.Count;
      Text EnvCounter = gameObject.transform.GetChild(1).GetComponent<Text>();
       EnvCounter.text = "Env Cards: "+ chosenEnvCards.Count;
    }
}
