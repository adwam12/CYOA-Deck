using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverController : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
       public void OnPointerEnter(PointerEventData eventData)
     {
        Debug.Log("BIG");
        gameObject.transform.localScale += new Vector3(1.5f,1.5f,2);
     }
         public void OnPointerExit(PointerEventData eventData)
     {
       gameObject.transform.localScale += new Vector3(-1.5f,-1.5f,-2);
         Debug.Log("SMALL");
     }
}