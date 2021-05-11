using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEngine.Events;
using UnityEngine.UI;


public class FightManager : MonoBehaviour
{
  public GameObject UiElements;
  public CreateCard Spawner;
  public Card goodOutcome;

  public GameObject playerSlider;

  public EnemyCard Enemy;

  public float enemyStamina;
  public float playerStamina;

  public int playerHP;
  public int enemyHP;
  public int playerMaxStamina;
  public string enemyName;

  public GameObject PlayerStats;

  // [SerializeField] Text cardText;
    // Start is called before the first frame update
    void Start()
    {   
        
        playerMaxStamina = PlayerStats.transform.GetComponent<PlayerStats>().MaxStamina;

        enemyStamina = Enemy.getEnemyStamina();
        enemyHP = Enemy.getEnemyHP();
        enemyName = Enemy.name;

        Debug.Log("STATS: " + PlayerStats.transform.GetComponent<PlayerStats>().Health);
        // playerHP = PlayerStats.transform.GetComponent<PlayerStats>().Health;


        UiElements.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Stamina: " + PlayerStats.transform.GetComponent<PlayerStats>().Stamina;
        UiElements.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Stamina: " + enemyStamina;
        UiElements.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "HP: " + enemyHP;
        UiElements.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "HP: " + PlayerStats.transform.GetComponent<PlayerStats>().Health;
        UiElements.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = enemyName;

        
    Button fightButton = UiElements.transform.GetChild(3).GetComponent<Button>();
    // topButton.onClick.AddListener(mainGame.makeNewCard);
      fightButton.onClick.AddListener(() => {
          float enemyAttack = setEnemyAttack();
          int playerAttack = setPlayerAttack((int)playerSlider.GetComponent<Slider>().value);

          if ((int)enemyAttack > playerAttack){
            Debug.Log("ENEMY WON WITH AN ATTACK OF " + (int)enemyAttack);
            if (playerAttack > 0){
              Debug.Log("PLAYER DID NOT BLOCK");
              PlayerStats.transform.GetComponent<PlayerStats>().Health = PlayerStats.transform.GetComponent<PlayerStats>().Health - Random.Range(1,(int)enemyAttack)+1;
              // UiElements.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "HP: " + (playerHP - Random.Range(1,(int)enemyAttack)+1);
            }else{
              Debug.Log("PLAYER BLOCKED");
              // UiElements.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "HP: " + (playerHP - Random.Range(0,3));
              PlayerStats.transform.GetComponent<PlayerStats>().Health = PlayerStats.transform.GetComponent<PlayerStats>().Health - Random.Range(0,3);
            }
          }
          if (playerAttack > (int)enemyAttack ){
            Debug.Log("PLAYER WON");
            if ((int)enemyAttack > 0){
              enemyHP = enemyHP - ((Random.Range(1,(int)playerAttack)+1) + PlayerStats.transform.GetComponent<PlayerStats>().Attack);

              // UiElements.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "HP: " + (enemyHP - Random.Range(1,playerAttack)+1);
            }else{
              enemyHP = enemyHP - (Random.Range(0,3) + PlayerStats.transform.GetComponent<PlayerStats>().Attack);
              // UiElements.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "HP: " + (enemyHP - Random.Range(0,3));
            }
          }
      });
    }

    // Update is called once per frame
    int setPlayerAttack(int chosenAttack)
    {
      Debug.Log("CHOSEN ATTACK: " + chosenAttack);
      UiElements.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "Player Attack: " + chosenAttack;
      if (chosenAttack == 0){
        PlayerStats.transform.GetComponent<PlayerStats>().Stamina = PlayerStats.transform.GetComponent<PlayerStats>().Stamina + 2;
      }else{
        PlayerStats.transform.GetComponent<PlayerStats>().Stamina = PlayerStats.transform.GetComponent<PlayerStats>().Stamina - chosenAttack;
      }
      if (PlayerStats.transform.GetComponent<PlayerStats>().Stamina > playerMaxStamina){
        PlayerStats.transform.GetComponent<PlayerStats>().Stamina = playerMaxStamina;
      }
      // if (enemyAttack <= 3){
      //   enemyStamina += 3;
      // }
      Debug.Log("New Stamina: " + PlayerStats.transform.GetComponent<PlayerStats>().Stamina );

      
      UiElements.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Stamina: " + PlayerStats.transform.GetComponent<PlayerStats>().Stamina;
      playerSlider.GetComponent<Slider>().maxValue = PlayerStats.transform.GetComponent<PlayerStats>().Stamina;

      return chosenAttack;

    }
    float setEnemyAttack()
    {
      float enemyAttack = Random.Range(0, enemyStamina+1);

      if (enemyAttack < 2.00f){
        enemyAttack = 0.00f;
      }
      // float enemyAttack = givenNumber;

      // Debug.Log("Enemy Attack: " + enemyAttack );
      // Debug.Log("Enemy Stamina: " + enemyStamina );

      UiElements.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = "Enemy Attack:" + enemyAttack.ToString("F2");
      if (enemyAttack == 0.00f){
        enemyStamina = enemyStamina + (Enemy.getEnemyStamina()/3);
      }else{
        enemyStamina = enemyStamina - enemyAttack;
        if (enemyStamina < 1.00f){
          enemyStamina = 0.00f;
        }
      }
      // if (enemyAttack < enemyStamina/2){
      //   Debug.Log("add Stamina");
      //   enemyStamina = enemyStamina + enemyStamina/3;
      // }else{
      //   enemyStamina = enemyStamina - enemyAttack/3;
      //   Debug.Log("Decrease Stamina");
      // }
      if (enemyStamina >= Enemy.getEnemyStamina()){
        enemyStamina = Enemy.getEnemyStamina();
      }
      // if (enemyAttack <= 3){
      //   enemyStamina += 3;
      // }
      // Debug.Log("New Stamina: " + enemyStamina );

      
      UiElements.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Stamina: " + enemyStamina;
      return enemyAttack;
      // playerSlider.GetComponent<Slider>().maxValue = enemyStamina;

    }

    void Update()
    {
      if ((playerSlider.GetComponent<Slider>().value > 0) & (PlayerStats.transform.GetComponent<PlayerStats>().Attack > 0))
      {
        playerSlider.transform.GetChild(0).GetComponent<Text>().text = playerSlider.GetComponent<Slider>().value.ToString() + " (+" + PlayerStats.transform.GetComponent<PlayerStats>().Attack + ")";
      }else{
        playerSlider.transform.GetChild(0).GetComponent<Text>().text = playerSlider.GetComponent<Slider>().value.ToString();
      }
      
  
          // Debug.Log("Test 1");
          // UiElements.transform.GetChild(1).GetComponent<Text>().text = "Picked Value: 1";
          // Debug.Log(UiElements.transform.GetChild(1).GetComponent<Text>().text);
          



      
      
        
    }
    private void LateUpdate() {
      UiElements.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "HP: " + PlayerStats.transform.GetComponent<PlayerStats>().Health;
      UiElements.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "HP: " + enemyHP;
      UiElements.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Stamina: " + PlayerStats.transform.GetComponent<PlayerStats>().Stamina;


      if ((int)playerSlider.GetComponent<Slider>().value < 1){
          UiElements.transform.GetChild(3).GetChild(0).GetComponent<Text>().text  = "Defend!";
      }else{
        if ((int)playerSlider.GetComponent<Slider>().value == playerMaxStamina )
        {
          UiElements.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Full Strike!";
        }else{
          UiElements.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Strike!";
        }
        
      }
      if (enemyHP < 1){
         Spawner.changeDir();
        //  Debug.Log("MANS WON!");
         GameObject newCard = Spawner.createNewCard("Card", goodOutcome, 283);
        //  gameObject.SetActive(false);
         this.enabled = false;
         Debug.Log("HELLO LAS HOW R YA");
      }
      // PlayerStats.transform.GetComponent<PlayerStats>().Health = playerHP;
    }
}
