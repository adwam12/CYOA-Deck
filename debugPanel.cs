using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
 


public class debugPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Button RestartButton;
    public Button ItemButton;

    public GameObject Canvas;
    public CreateCard CardSpawner;

    void Start()
    {
      RestartButton.onClick.AddListener(()=>{
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name) ;
      });
      ItemButton.onClick.AddListener(()=>{
        GameObject newItemCard = CardSpawner.createItemCard("common", Canvas.transform.GetChild(Canvas.transform.childCount - 1).position);
        
      });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
