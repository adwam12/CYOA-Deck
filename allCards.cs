using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class allCards : MonoBehaviour
{
  public Card[] Cards;
  public ItemCard[] Items;
  public GameObject cardTemplate;
  public GameObject itemTemplate;
  public GameObject ParentPanel;


    // Start is called before the first frame update
    void Start()
    {
      for (var i = 0; i < Cards.Length; i++){
        var newEnvCard = Instantiate(cardTemplate);
        newEnvCard.transform.GetComponent<SelectedCards>().EnvCard = Cards[i];
        newEnvCard.name = newEnvCard.transform.GetComponent<SelectedCards>().EnvCard.name;
        Text CardText = newEnvCard.transform.GetChild(0).GetComponent<Text>();
        CardText.text = newEnvCard.name;
        newEnvCard.transform.SetParent(ParentPanel.transform);
      }     

      for (var i = 0; i < Items.Length; i++){
        var newItemCard = Instantiate(itemTemplate);
        newItemCard.transform.GetComponent<SelectedCards>().item = Items[i];
        newItemCard.name = newItemCard.transform.GetComponent<SelectedCards>().item.name;
        Text itemText = newItemCard.transform.GetChild(0).GetComponent<Text>();
        itemText.text = newItemCard.name;
        Image itemImage = newItemCard.transform.GetChild(1).GetComponent<Image>();
        itemImage.sprite = Items[i].getSprite();
        // Debug.Log();


        
        newItemCard.transform.SetParent(ParentPanel.transform);
      }   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
