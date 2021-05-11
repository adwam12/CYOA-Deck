using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OpenInv : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject MainUI;
    public GameObject Camera;
    public Button OpenInvButton;
    public Button OpenEquipButton;

    public GameObject EquipPanel;
    public GameObject InvPanel;
    public GameObject tabText;
    public GameObject CurrentPanel;
    public bool isOpen;

    void Start()
    {
        isOpen = false;

        OpenEquipButton.onClick.AddListener(() =>
        {
          // EquipPanel.SetActive(false);
          if (isOpen){
            if (!(CurrentPanel == EquipPanel)){
              EquipPanel.transform.SetAsLastSibling();
              CurrentPanel = EquipPanel;
            }else{
              openInv();
            }
            
          }else{
            EquipPanel.transform.SetAsLastSibling();
            CurrentPanel = EquipPanel;
            openInv();
          }
          
        });
        OpenInvButton.onClick.AddListener(() =>
        {
          if (isOpen){
            if (!(CurrentPanel == InvPanel)){
              InvPanel.transform.SetAsLastSibling();
              CurrentPanel = InvPanel;
            }else{
              openInv();
            }
            
          }else{
            openInv();
            InvPanel.transform.SetAsLastSibling();
            CurrentPanel = InvPanel;
          }
        });
    }

    public void openInv(){
      if (isOpen){
        tabText.GetComponent<Text>().text = "↑";
        
        isOpen = false;
      }else{
        isOpen = true;
        tabText.GetComponent<Text>().text = "↓";
        
      }
    }

    // Update is called once per frame
    void Update()
    {

     if (isOpen){
        MainUI.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 230, MainUI.transform.position.z);
        gameObject.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 20, MainUI.transform.position.z);
        // isOpen = false;
      }else{
        MainUI.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 590, MainUI.transform.position.z);
        gameObject.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 380, Camera.transform.position.z);
        // isOpen = true;
      }
    }
}
