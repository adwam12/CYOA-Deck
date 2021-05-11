using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      foreach(Transform child in GameObject.Find("InnerPanel").transform)
        {
            Destroy(child.gameObject);
            // Debug.Log(child.gameObject);
        }
        GameObject.Find("Game").transform.GetComponent<EquipmentScript>().clearAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
