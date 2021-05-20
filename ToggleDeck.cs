using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleDeck : MonoBehaviour
{

  public bool isOpen;
  public GameObject EqpPanel;
  public GameObject EnvPanel;
  public Button OpenInvButton;
  public Button OpenEquipButton;
  public GameObject CurrentPanel;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;

        OpenEquipButton.onClick.AddListener(() =>
        {
          // EquipPanel.SetActive(false);
          if (isOpen){
            if (!(CurrentPanel == EqpPanel)){
              EqpPanel.transform.SetAsLastSibling();
              CurrentPanel = EqpPanel;
            }
            
          }else{
            EqpPanel.transform.SetAsLastSibling();
            CurrentPanel = EqpPanel;
          }
          
        });
        OpenInvButton.onClick.AddListener(() =>
        {
          if (isOpen){
            if (!(CurrentPanel == EnvPanel)){
              EnvPanel.transform.SetAsLastSibling();
              CurrentPanel = EnvPanel;
            }
            
          }else{
            EnvPanel.transform.SetAsLastSibling();
            CurrentPanel = EnvPanel;
          }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
