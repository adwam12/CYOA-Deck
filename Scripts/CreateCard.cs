using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CreateCard : MonoBehaviour
{

  public GameObject cardTemplate;

  public bool writeOnCardSpawn;

  public GameObject itemTemplate;
  public Transform parent;

  public Transform InvParent;

  public GameObject InvCardTemplate;


  [SerializeField] CardList EnvCards;
  public CameraFollow newAngle;

  private Button yourButton2;
  public MainGame mainGame;
  private float distanceHor;
  private float distanceVert;


  public Vector3 CardPos;

  private int lastDir;
  private LineRenderer lineRend;
  public int lengthOfLineRenderer;

  public GameObject newCardMaker;

  private int numOfCards;
  private Vector3[] StoredPositions;


  private Vector3[] points;

  // public ItemCard itemCards;
  [SerializeField] CardList itemCards;
  public GameObject fightManager;
  public GameObject PlayerStats;



  // Start is called before the first frame update
  void Start()
  {
    CardPos = new Vector3(1200, 360, 0.0f);
    distanceHor = 1200;
    distanceVert = 360;
    numOfCards = 1;
    lengthOfLineRenderer = 50;
    points = new Vector3[lengthOfLineRenderer];

    // createNewCard("Type of Card Here");

    // newCard.text = newCard.getCardText();
    // Text mainText = newCardTitle.GetComponent(a.transform.Find("CardText"));
    // newCard.text = newCard.getCardText();
    // Text litText = newCardTitle.GetComponent("Text");
    // Debug.Log();
    // Debug.Log(newCard.getCardText());
    // objToSpawn1.AddComponent<Image>();

  }
  // Card card;

  public GameObject createItemCard(string Rarity, Vector3 Itemposition)
  {
    GameObject a = Instantiate(itemTemplate);
    a.transform.SetParent(parent);
    a.transform.position = Itemposition;
    // Debug.Log("LAST CHILD: " + parent.transform.GetChild(parent.transform.childCount - 1));
    ItemCard newItemCard;


    newItemCard = itemCards.getItemCard(Rarity);

    Text newCardText = a.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>();
    Scrollbar newCardScrollValue = a.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Scrollbar>();

    Text newCardTitle = a.transform.GetChild(0).GetComponent<Text>();
    Text firstOption = a.transform.GetChild(3).GetChild(0).GetComponent<Text>();
    Image itemImage = a.transform.GetChild(2).GetComponent<Image>();
    // newItemCard.image.color = itemImage;
    // Debug.Log();


    newCardText.text = newItemCard.getItemDesc();
    newCardTitle.text = newItemCard.name;
    firstOption.text = newItemCard.getOption1();
    itemImage.sprite = newItemCard.getSprite();
    newCardScrollValue.value = 1;
    // Debug.Log(itemImage);


    Button topButton = a.transform.GetChild(3).GetComponent<Button>();
    // topButton.onClick.AddListener(mainGame.makeNewCard);
    topButton.onClick.AddListener(() =>
    {

      addToInventory(a, newItemCard.usable, newItemCard);
      Destroy(a);
    });

    // a.onClick.AddListener(()=>{
    //   destroy(a);
    // });

    return a;

  }
  public static void SetRight(RectTransform rt, float right)
  {

    // RectTransform rt = InvParent.transform.GetComponent<RectTransform>();
    // rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    rt.sizeDelta = new Vector2(rt.sizeDelta.x + 243, rt.sizeDelta.y);

  }
  public GameObject button;
  public void addToInventory(GameObject itemCard, bool isUsable, ItemCard itemToUse)
  {
    // var lastChild = InvParent.transform.GetChild(InvParent.transform.childCount - 1);
    // Debug.Log(InvParent.GetComponent<RectTransform>());
    SetRight(InvParent.transform.GetComponent<RectTransform>(), 1050);
    GameObject newInvItem = Instantiate(InvCardTemplate);
    newInvItem.name = itemToUse.name;
    newInvItem.transform.SetParent(InvParent);
    // newInvItem.transform.position = new Vector3(lastChild.transform.position.x + 220, lastChild.transform.position.y, lastChild.transform.position.z);
    newInvItem.transform.localScale = InvCardTemplate.transform.localScale;
    newInvItem.transform.GetChild(0).GetComponent<Text>().text = itemCard.transform.GetChild(0).GetComponent<Text>().text;
    newInvItem.transform.GetChild(1).GetComponent<Text>().text = itemCard.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>().text;
    newInvItem.transform.GetChild(2).GetComponent<Image>().sprite = itemCard.transform.GetChild(2).GetComponent<Image>().sprite;
    Button useItemButton = newInvItem.transform.GetChild(3).GetComponent<Button>();
    // Destroy(newInvItem.transform.GetChild(3));


    if (isUsable)
    {
      //! LOGIC FOR HEALTH INCREASE
      newInvItem.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = itemToUse.getOption1();
      // GameObject newButton = Instantiate(button) as GameObject;
      if (itemToUse.healthUp)
      {
        Debug.Log("INCREASE HEALTH BY: " + itemToUse.IncreaseHealthBy);
        useItemButton.onClick.AddListener(() =>
        {
          Debug.Log("BONUS: " + PlayerStats.transform.GetComponent<PlayerStats>().Health);
          PlayerStats.transform.GetComponent<PlayerStats>().Health = PlayerStats.transform.GetComponent<PlayerStats>().Health + itemToUse.IncreaseHealthBy;
          Destroy(newInvItem);
        });
      }

      //! LOGIC FOR MAX HEALTH INCREASE
      if (itemToUse.maxHealthUp)
      {
        Debug.Log("INCREASE MAX HEALTH BY: " + itemToUse.IncreaseMaxHealthBy);
        useItemButton.onClick.AddListener(() =>
        {

          PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth = PlayerStats.transform.GetComponent<PlayerStats>().MaxHealth + itemToUse.IncreaseMaxHealthBy;
          Destroy(newInvItem);
        });
      }

      if (itemToUse.staminaUp)
      {
        //! LOGIC FOR STAMINA INCREASE
        Debug.Log("INCREASE Stamina BY: " + itemToUse.IncreaseStaminaBy);
        useItemButton.onClick.AddListener(() =>
        {
          Debug.Log("BONUS: " + PlayerStats.transform.GetComponent<PlayerStats>().Stamina);
          PlayerStats.transform.GetComponent<PlayerStats>().Stamina = PlayerStats.transform.GetComponent<PlayerStats>().Stamina + itemToUse.IncreaseStaminaBy;
          Destroy(newInvItem);
        }
        );

      }
      if (itemToUse.equipable)
      {
        useItemButton.onClick.AddListener(() =>
        {
          Debug.Log(itemToUse.itemType);
          PlayerStats.transform.GetComponent<EquipmentScript>().equip(itemToUse);
          Destroy(newInvItem);
        });

      }


    }
    else
    {
      useItemButton.gameObject.SetActive(false);
    }
  }
  public void ApplyDamage(float damage)
  {
    Debug.Log("WE GOT THE MSG!!");
  }

  public IEnumerator TypewriterEffect(string text, Text destination)
  {
    yield return new WaitForSeconds(2);
    if (newAngle.shouldStartTyping())
    {
      foreach (char character in text.ToCharArray())
      {
        destination.text += character;
        Debug.Log("TEXT HERE:");
        yield return new WaitForSeconds(0.02f);
      }
    }
  }

  public GameObject createNewCard(string chosenType, Card chosenCard, float xcoord)
  {

    GameObject a = Instantiate(cardTemplate);
    a.transform.SetParent(parent);
    // a.transform.Translate(CardPos, Camera.main.transform);
    a.transform.position = CardPos;
    Card newCard;
    Card randomFirstCard;
    Card randomSecondCard;
    newCard = chosenCard;

    if (chosenType == "Card")
    {
      Debug.Log("GIVEN A TYPE");
      // newCard = chosenCard;
      Debug.Log(chosenCard.randomizeFirst);
      if ((chosenCard.randomizeFirst) | (chosenCard.randomizeFirst))
      {
        if (chosenCard.randomizeFirst)
        {
          randomFirstCard = chosenCard.getRandomCard(0);
        }
        if (chosenCard.randomizeSecond)
        {
          randomSecondCard = chosenCard.getRandomCard(1);
        }
      }

    }
    else
    {
      Debug.Log("NO TYPE");
      newCard = EnvCards.getEnvCard();
    }

    Card[] cardsArray = newCard.getOtherCards();

    Text newCardText = a.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>();
    Scrollbar newCardScrollValue = a.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Scrollbar>();

    Text newCardTitle = a.transform.GetChild(0).GetComponent<Text>();
    Text firstOption = a.transform.GetChild(2).GetChild(0).GetComponent<Text>();
    Text secondOption = a.transform.GetChild(3).GetChild(0).GetComponent<Text>();
    // newCardText.text = newCard.getCardText();
    // TypewriterEffect(, newCardText );
    newCardText.text = "";
    // if (writeOnCardSpawn){
    StartCoroutine(TypewriterEffect(newCard.getCardText(), newCardText));
    // }




    newCardTitle.text = newCard.name;
    firstOption.text = newCard.getOption1();
    secondOption.text = newCard.getOption2();
    newCardScrollValue.value = 1;
    // Debug.Log(newCard.getOtherCards());

    if (chosenCard.findLoot)
    {
      for (int i = 0; i < chosenCard.lootToFind; i++)
      {
        createItemCard(chosenCard.itemRarity.ToString(), a.transform.position);
      }

    }


    // Debug.Log(cardsArray[0]);

    Button topButton = a.transform.GetChild(2).GetComponent<Button>();
    Button bottomButton = a.transform.GetChild(3).GetComponent<Button>();
    // topButton.onClick.AddListener(mainGame.makeNewCard);
    topButton.onClick.AddListener(() =>
    {

      StopAllCoroutines();
      newCardText.text = newCard.getCardText();

      changeDir();
      Debug.Log("CHANGE DIR FROM TOP");
      if (newCard.FirstChoiceFight)
      {
        // Debug.Log("POSITION HERE");
        // Debug.Log(a.transform.position);
        StartFight(CardPos, newCard.Enemy, newCard.Goodoutcome);

      }
      else
      {

        if (chosenCard.randomizeFirst)
        {
          // randomFirstCard = chosenCard.getRandomCard(0);
          Card FirstRando = chosenCard.getRandomCard(0);
          newCardMaker = createNewCard("Card", FirstRando, distanceHor + 1200);

          Debug.Log(FirstRando);
        }
        else
        {
          newCardMaker = createNewCard("Card", cardsArray[0], distanceHor + 1200);
        }


      }
      bottomButton.interactable = false;
      topButton.enabled = false;
      // distanceHor += 450;


    });




    bottomButton.onClick.AddListener(() =>
    {
      // newCardText.text = newCard.getCardText();
      StopAllCoroutines();
      newCardText.text = newCard.getCardText();
      changeDir();
      Debug.Log("CHANGE DIR FROM Bottom");
      if (newCard.SecondChoiceFight)
      {
        // Debug.Log("POSITION HERE");
        // Debug.Log(a.transform.position);
        StartFight(CardPos, newCard.Enemy, newCard.Goodoutcome);

      }
      else
      {
        if (chosenCard.randomizeSecond)
        {
          // randomFirstCard = chosenCard.getRandomCard(0);
          Card SecondRando = chosenCard.getRandomCard(1);
          newCardMaker = createNewCard("Card", SecondRando, distanceHor + 1200);
          // moveArrow(newCardMaker);

        }
        else
        {
          newCardMaker = createNewCard("Card", cardsArray[1], distanceHor + 1200);

        }

      }

      // distanceHor += 450;
      topButton.interactable = false;
      bottomButton.enabled = false;
    });





    // Debug.Log(newCard.otherCards);

    newAngle.changeTarget(a);
    a.name = newCard.name;

    // StoredPositions.Add(newTarget.transform.position);
    // Debug.Log("BELOW IS NEW");
    // Debug.Log(a.name);
    // moveArrow(a.transform.position);





    // Button btn2 = yourButton2.GetComponent<Button>();
    // btn2.onClick.AddListener(mainGame.makeNewCard);
    return a;
  }

  // Update is called once per frame

  public void StartFight(Vector3 givenPosition, EnemyCard enemyToFight, Card goodOutcome)
  {
    Debug.Log(enemyToFight);
    Debug.Log("FIGHT!");
    // changeDir();
    // Debug.Log(givenPosition);
    // Debug.Log(givenPosition);
    // Debug.Log(givenPosition);
    // GameObject newFightCard = Instantiate(fightManager, parent, true);
    GameObject newFightCard = Instantiate(fightManager);
    newFightCard.transform.SetParent(parent);
    newFightCard.transform.position = CardPos;
    // newFightCard.transform.Translate(CardPos, Space.Self);

    newFightCard.name = enemyToFight.name;
    newAngle.changeTarget(newFightCard);
    // newFightCard.transform.GetComponent("FightManager").setEnemyHP(200);
    // Text newCardTitle = newFightCard.transform.GetChild(0).GetComponent<Text>();

    // Text firstOption = newFightCard.transform.GetChild(3).GetChild(0).GetComponent<Text>();
    // Debug.Log(newFightCard.getEnemyHP());
    newFightCard.GetComponent<FightManager>().Enemy = enemyToFight;
    newFightCard.GetComponent<FightManager>().goodOutcome = goodOutcome;

    // Debug.Log();
    Debug.Log(enemyToFight.getEnemyHP());
    // Debug.Log(Card);
    // newFightCard.
    // newFightCard.transform.Translate(CardPos, Camera.main.transform);

    // ItemCard newItemCard;


  }

  public Vector3 changeDir()
  {
    int dir = Random.Range(0, 3);
    Debug.Log("DIRECTION: " + dir + " LAST DIRECTION: " + lastDir);
    Debug.Log("CARD POSITION BEFORE CHANGE: " + CardPos);

    // if (dir == 0)
    // {
    //   distanceHor += 450;
    // }
    if ((dir == 1) & !(lastDir == 2))
    {
      Debug.Log("GOING UP");
      distanceVert += 600;
    }
    else
    {
      if ((dir == 2) & !(lastDir == 1))
      {
        Debug.Log("GOING DOWN");
        distanceVert -= 600;
      }
      else
      {
        distanceHor += 450;
        Debug.Log("GOING Right");
      }
    }
    CardPos.Set(distanceHor, distanceVert, 0);
    lastDir = dir;
    Debug.Log("CARD POSITION AFTER CHANGE: " + CardPos);



    return CardPos;


  }

  public void moveArrow(Vector3 newTarget)
  {

    //ONLY WORKS UP TO 50 CARDS RIGHT NOW BC THATS THE SET ARRAY SIZE. LATER CREATE NEW ARRAY WITH +1 size and copy items into it

    // StoredPositions = newTarget.transform.position.ToArray();

    Debug.Log("ADDING LINE POINT");

    lineRend = GetComponent<LineRenderer>();
    // Debug.Log(numOfCards);
    // lengthOfLineRenderer = numOfCards;

    // // lineRend.positionCount = 2;
    points[0] = new Vector3(766, 360, 0.0f);
    // for (int i = 0; i < numOfCards; i++)
    //   {
    // Debug.Log(numOfCards);

    points[numOfCards] = new Vector3(newTarget.x, newTarget.y, 3);

    // }
    // points.Push(CardPos);
    lineRend.positionCount = numOfCards + 1;
    numOfCards += 1;


    // Debug.Log(lineRend.positionCount);
    lineRend.SetPositions(points);
  }
  void Update()
  {

  }
}
