using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour {

Camera mainCamera;

void OnStart(){
    mainCamera = Camera.main;
    
}
void OnBecameInvisible(){
  
  //Debug.Log("Curr x : " + transform.position.x + " // Curr y : " + transform.position.y);
  transform.Translate(new Vector2(20f,0));
  //transform.position = new Vector3(Camera.main.transform.position.x + 9.3f,transform.position.y);
  
 }


}
