using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    // Start is called before the first frame update

    private LineRenderer lineRend;
    public string test;
    private Vector2 currentCard;
    private Vector2 nextCard;
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void updateLine()
    {
      lineRend.SetPosition(0,new Vector3(1200, 370, 0.0f));
      lineRend.SetPosition(1,new Vector3(1900, 370, 0.0f));


    }
}
