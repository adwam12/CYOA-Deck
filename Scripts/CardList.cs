using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class CardList : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Card[] EnvironmentCards;
    [SerializeField] ItemCard[] ItemCards;

    Card card;
    ItemCard itemcard;

    public Card getEnvCard()
    {
      // return EnvironmentCards;
      // Debug.Log(EnvironmentCards[Random.Range(0, 2)].getOtherCards());
      
      card = EnvironmentCards[Random.Range(0, EnvironmentCards.Length)];

      return card;

    }

    public ItemCard getItemCard(string rarityOfItem)
    {
      // int checkedItem = 0;
      // Random random = new Random();
      for (int i = ItemCards.Length - 1; i > 0; i--)
      {
        int randomIndex = Random.Range(0, i + 1);
        ItemCard temp = ItemCards[i];
        ItemCards[i] = ItemCards[randomIndex];
        ItemCards[randomIndex] = temp;
      }

      for (int checkedItem = 0; checkedItem < ItemCards.Length; checkedItem++)
      {
        Debug.Log(ItemCards[checkedItem].itemRarity);
        if (ItemCards[checkedItem].itemRarity.ToString() == rarityOfItem){
          return ItemCards[checkedItem];
        }
      }
      // Enumerable.Range(0, ItemCards.Length).OrderBy(c => random.Next()).ToArray();
      // IEnumerable<int> numbers = Enumerable.Range(1, 10).Select(x => x * x);

      Debug.Log("RANDOM ARRYA: "  );
      // for (checkedItem; checkedItem < ItemCards.Length; checkedItem++)
      // {
      //   itemcard = ItemCards[Random.Range(0, ItemCards.Length)];
      // }
      itemcard = ItemCards[Random.Range(0, ItemCards.Length)];

      return itemcard;

    }


    // public envCards[] envCardsArray = card.getOtherCards();

    // Update is called once per frame
    void Update()
    {
        
    }
}
