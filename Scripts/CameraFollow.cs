using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public CreateCard Spawner;
    public GameObject StartingTarget;

    public Vector3 offset;

    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;

    // public GameObject EndTarget;


     void Start()
     {
         StartCoroutine(LateStart(0.5f));
     }
 
     IEnumerator LateStart(float waitTime)
     {
       
         yield return new WaitForSeconds(waitTime);
         //Your Function You Want to Call
         changeTarget(StartingTarget);
     }
    void LateUpdate() {
      if (Spawner){
        newTarget(target);
      }

    }

    public void newTarget(Transform trans){
      desiredPosition = trans.position + offset;
      smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
      transform.position = smoothedPosition;
      // Debug.Log(desiredPosition.x);
      // Debug.Log(Vector3.Distance(desiredPosition, transform.position));

      
    }

    public bool shouldStartTyping(){
      // Debug.Log("NAME OF TARGET: " + );
      if (Vector3.Distance(desiredPosition, transform.position) < 10){
        return true;
      }
      return false;
    }
    public void changeTarget(GameObject targetedObject){
      Debug.Log("SETTING A NEW CAMERA TARGET");
      target = targetedObject.transform;
      // EndTarget = targetedObject;
      Debug.Log(target.position);
      if (Spawner){
        Spawner.moveArrow(target.position);
      }

      
      // Vector3 desiredPosition = trans.position + offset;
      // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
      // transform.position = smoothedPosition;
    }
}
