using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Events;

public class MainGame : MonoBehaviour
{
  [SerializeField] Text cardTitle;
  [SerializeField] Text cardText;

  [SerializeField] Card startCard;
  [SerializeField] CardList EnvCards;


  [SerializeField] Text buttonText1;
  [SerializeField] Text buttonText2;

  [SerializeField] Button button1;
  [SerializeField] Button button2;
  [SerializeField] GameObject LineControllerMain;

  public Button yourButton;
  public Button yourButton2;
  public GameObject objToSpawn;

  // public Canvas mainCanvas;

  public CreateCard Spawner;

  private float distanceHor;

  private ItemCard item;

  Card card;
    void Start()
    {

      card = startCard;
      cardText.text = card.getCardText();
      cardTitle.text = card.name;
      buttonText1.text = card.getOption1();
      buttonText2.text = card.getOption2();
      Button btn = yourButton.GetComponent<Button>();
      btn.onClick.AddListener(makeNewCard);

      Button btn2 = yourButton2.GetComponent<Button>();
      btn2.onClick.AddListener(makeNewCard);
      distanceHor = 250;


    }

    // Update is called once per frame
    void Update()
    {
      GameMain();   
    }

    private void GameMain()
    {

      if (Input.GetKeyDown(KeyCode.DownArrow))
      {
        //! SPAWN NEW ITEM FOR TESTING
          GameObject newItemCard = Spawner.createItemCard("common", objToSpawn.transform.position);
      }
    }


    void getEnvCard()
    {
      GameObject.Find("LineController");
      card = EnvCards.getEnvCard();
      // cardText.text = card.getCardText();
      cardText.text = card.getCardText();
      cardTitle.text = card.name;
      buttonText1.text = card.getOption1();
      buttonText2.text = card.getOption2();
    }

    public void makeNewCard()
    {
      GameObject newCard = Spawner.createNewCard("EMPTY", card, distanceHor + 1200);
      Debug.Log("newCard.transform.position");

      distanceHor += 450;
    }
    public void testdebug(){
      Debug.Log("Test Debug");
    }

    public void populateItem(){
      Debug.Log("NUMBER: " + GameManager.chosenItemsCards.Count);
    }
}
