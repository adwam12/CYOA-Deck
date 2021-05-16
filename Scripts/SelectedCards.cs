using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class SelectedCards : MonoBehaviour, IPointerClickHandler
{
    // public GameObject selected;
	// [SerializeField]
  
// private UnityEvent OnMouseClick = new UnityEvent();

[SerializeField] public UnityEvent onClick;
[SerializeField] public ItemCard item;
[SerializeField] public Card EnvCard;

[SerializeField] public GameObject Deck;
[SerializeField] private bool inDeck;
[SerializeField] public Color glowColor;
[SerializeField] public Color defaultColor;




// [SerializeField] private bool Selected;

	private void Update()
	{
		// If left mouse button pressed
		// if(Input.GetMouseButtonDown(0))
		// {
		// 	OnMouseClick.Invoke();
		// }
    if (inDeck){
      // Debug.Log(gameObject.GetComponent<Image>().color);
      gameObject.GetComponent<Image>().color = defaultColor;
        // float H, S, V;

        // Color.RGBToHSV(new Color(0.9f, 0.7f, 0.1f, 1.0F), out H, out S, out V);
        // Debug.Log("H: " + H + " S: " + S + " V: " + V);

    }else{
      gameObject.GetComponent<Image>().color = new Color(defaultColor.r - (defaultColor.r/2.5f), defaultColor.g -(defaultColor.g/2.5f), defaultColor.b -(defaultColor.b/2.5f));

      // Debug.Log(defaultColor.r);
    }
	}

	// Hook this up in the inspector.
	// public void MouseClicked()
	// {
	// 	Debug.Log("NAME: " );
	// }

    // void Start()
    // {
    //   Debug.Log("HI");
        
    // }
    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     Debug.Log("The cursor entered the selectable UI element: " + gameObject.name);
    // }
        public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!", this);
        if (item)
        {
          if (Deck.GetComponent<CardDeck>().addItemToDeck(item)){
            inDeck = true;
          }else{
             inDeck = false;           
          }

        }else{
          if (Deck.GetComponent<CardDeck>().addCardToDeck(EnvCard)){
            inDeck = true;
          }else{
            inDeck = false;  
          }

        }

        // invoke your event
        onClick.Invoke();
    }

}
