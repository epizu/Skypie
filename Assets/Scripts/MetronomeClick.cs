using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeClick : MonoBehaviour {

	// Use this for initialization


		 void Start(){
			 Debug.Log("MetronomeClick Initiation!");
        }
        void OnTick(int[] metronomeInfo){

        Debug.Log( "Tick from metronome click" );
	

			 if(metronomeInfo[2] == 0){
    				GetComponent<AudioSource>().Play();
			 }
		}
		
}
