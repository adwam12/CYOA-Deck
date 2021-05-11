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



  // public CameraFollow newAngle;

  Card card;
    // Start is called before the first frame update
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

      // Canvas HomeCanvas = mainCanvas.GetComponent<Canvas>();

      // Spawner = GameObject.Find("CardSpawner");
      distanceHor = 250;

      // test = "hi";


    }

    // Update is called once per frame
    void Update()
    {
      GameMain();   
    }

    private void GameMain()
    {
      // Card[] cardsArray = card.getOtherCards();
      // if (Input.GetKeyDown(KeyCode.LeftArrow))
      // {
      //   // card = cardsArray[0];
      // }
      // if (Input.GetKeyDown(KeyCode.RightArrow))
      // {
      //   Debug.Log(LineControllerMain.GetComponent("LineRenderer"));
        

      // }
      if (Input.GetKeyDown(KeyCode.DownArrow))
      {
          GameObject newItemCard = Spawner.createItemCard("common", objToSpawn.transform.position);
          // Spawner.addToInventory(newItemCard);

      }

      // button1.onClick()
      // {

      // }
      

      // cardText.text = card.getCardText();
      // cardText.color = card.getCardColor();
      // cardTitle.text = card.name;


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


      // Debug.Log(card.getCardText());

      // card.text = card.getCardText();
      // cardText.color = card.getCardColor();
      // cardTitle.text = card.name;
      // return "hi";
    }

    public void makeNewCard()
    {


      // Debug.Log(lineRend.Positions);
      // lineRend.SetPositions(1200, 370, 0);
      // card = EnvCards.getEnvCard();
      // // cardText.text = card.getCardText();
      // cardText.text = card.getCardText();
      // cardTitle.text = card.name;
      // buttonText1.text = card.getOption1();
      // buttonText2.text = card.getOption2();

      // GameObject newCard = Spawner.createNewCard("EMPTY",card, distanceHor + 1200);
      GameObject newCard = Spawner.createNewCard("EMPTY", card, distanceHor + 1200);
      Debug.Log("newCard.transform.position");
      // Spawner.moveArrow(newCard.transform.position);

      
      distanceHor += 450;


      // newAngle = Camera.main.GetComponent("CameraFollow").target;
      // newDeal.

      // card = newCard;
      // Debug.Log(topButton);


      // Debug.Log(bottomButton);

      
      // Debug.Log(newAngle.newTarget(objToSpawn.transform));
      
      // objToSpawn.SetParent(mainCanvas);
      // objToSpawn.transform.SetParent(mainCanvas.GetComponent<Canvas>());
      // card.text = card.getCardText();
      // cardText.color = card.getCardColor();
      // cardTitle.text = card.name;
      // return "hi";
    }
    public void testdebug(){
      Debug.Log("Test Debug");
    }
}
