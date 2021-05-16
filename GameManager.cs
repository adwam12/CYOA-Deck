using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static List<Card> chosenEnvCards = new List<Card>();
    public static List<ItemCard> chosenItemsCards = new List<ItemCard>();



    // Start is called before the first frame update
    void Start()
    {
      // Debug.Log();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("HDJS");
              // chosenItemsCards = GameObject.Find("Deck").GetComponent<CardDeck>().chosenItemsCards;
        // Debug.Log(chosenItemsCards.Count);

        
    }

    public void StartGame(){
      SceneManager.LoadScene("SampleScene");
      chosenItemsCards = GameObject.Find("Deck").GetComponent<CardDeck>().chosenItemsCards;
      chosenEnvCards = GameObject.Find("Deck").GetComponent<CardDeck>().chosenEnvCards;

    }
}
