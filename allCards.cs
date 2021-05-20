using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class allCards : MonoBehaviour
{
  public Card[] Cards;
  public ItemCard[] Items;
  public Card[] PathUpgrade;
  public GameObject cardTemplate;
  public GameObject itemTemplate;
  public GameObject ParentPanel;
  public GameObject EnvParentPanel;
  public GameObject HorizontalEnvPanel;



    // Start is called before the first frame update
    public void createUpgradeCard(Transform EnvParent, Card desiredCard){
      var newChild = Instantiate(cardTemplate);
      newChild.transform.GetComponent<SelectedCards>().EnvCard = desiredCard;
      newChild.transform.name = desiredCard.name;
      Text CardText = newChild.transform.GetChild(0).GetComponent<Text>();
      CardText.text = desiredCard.name;
      newChild.transform.GetComponent<SelectedCards>().isChild = true;
      newChild.transform.SetParent(EnvParent);

    }
    void Start()
    {
      for (var i = 0; i < Cards.Length; i++){
        var newEnvCardMaster = Instantiate(HorizontalEnvPanel);
        newEnvCardMaster.transform.GetChild(1).GetComponent<SelectedCards>().EnvCard = Cards[i];
        var parentCard = newEnvCardMaster.transform.GetChild(1).GetComponent<SelectedCards>().EnvCard;
        newEnvCardMaster.transform.GetChild(1).name = parentCard.name;
        Text CardText = newEnvCardMaster.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        CardText.text = newEnvCardMaster.transform.GetChild(1).name;
        newEnvCardMaster.transform.SetParent(EnvParentPanel.transform);
        newEnvCardMaster.transform.GetChild(1).localScale += new Vector3(0.10f,0.10f,0.10f);

        if (parentCard.EnvChild.Length > 0){
          for (var e = 0; e < parentCard.EnvChild.Length; e++){
            Debug.Log("CHILD CARD NUMBER " + e + " is called: " + parentCard.EnvChild[e].name);
            createUpgradeCard(newEnvCardMaster.transform.GetChild(0), parentCard.EnvChild[e]);
          }
        }
      }    
      for (var i = 0; i < PathUpgrade.Length; i++){
        Debug.Log("IS UNLOCKED: " + PathUpgrade[i].unlocked);
        PathUpgrade[i].unlocked = false;
        // var newEnvCard = Instantiate(cardTemplate);
        // newEnvCard.transform.GetComponent<SelectedCards>().EnvCard = Cards[i];
        // newEnvCard.name = newEnvCard.transform.GetComponent<SelectedCards>().EnvCard.name;
        // Text CardText = newEnvCard.transform.GetChild(0).GetComponent<Text>();
        // CardText.text = newEnvCard.name;
        // newEnvCard.transform.SetParent(EnvParentPanel.transform);
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
