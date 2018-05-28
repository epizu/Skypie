using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

        public GameObject[] objects;
        public int state;
        public bool isOn;
        public bool debug;
        private double startTime;
        void OnStart(){
                state = 0;
                isOn = false;
                debug = true;
             
              
        }
        void OnTick(){
                
                if(isOn)
                        state = (state + 1) % 32;
                else{
                        state = 0;
                        isOn = true;
                           startTime = AudioSettings.dspTime;
                          Debug.Log("start time! :  " + startTime);

                }

                if(state == 24 || state == 8)
                {
                                Instantiate(objects[0], new Vector2(objects[0].transform.position.x,0),Quaternion.identity).transform.Translate(new Vector2(31,0));
                           
                                        Debug.Log(state);
                            
                }
                        

                if(AudioSettings.dspTime - startTime > 44 && (state == 14 || state == 20 || state == 26 || state == 30 || state == 4)){
                        Instantiate(objects[2], new Vector2(objects[2].transform.position.x,3),Quaternion.identity).transform.Translate(new Vector2(31,0));

                        Debug.Log("dsp: " + AudioSettings.dspTime);
                }   
                        
                if(state == 16 || state == 0)
                        Instantiate(objects[1], new Vector2(objects[1].transform.position.x,1),Quaternion.identity).transform.Translate(new Vector2(31,0));    

        }
	
	// Update is called once per frame
}
