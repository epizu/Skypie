using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

        public GameObject[] objects;
        public int state;
        public bool isOn;
        public bool debug;
        private double startTime;
        private int downbeatCount, measureCount,tickCount,isDownBeat;
        void OnStart(){
                state = 0;
                isOn = false;
                debug = true;
             
              
        }
        void OnTick(int[] metronomeInfo){

                measureCount = metronomeInfo[0];   
                downbeatCount = metronomeInfo[1];
                tickCount = metronomeInfo[2];
                isDownBeat = metronomeInfo[3];
     
                if(!isOn){
                        state = 0;
                        isOn = true;
                           startTime = AudioSettings.dspTime;
                          //Debug.Log("start time! :  " + startTime);

                } 

                if(measureCount >= 4){



   

                if(isDownBeat == 1 && (downbeatCount == 0 || downbeatCount == 2))
                {
                                Instantiate(objects[0], new Vector2(objects[0].transform.position.x,0),Quaternion.identity).transform.Translate(new Vector2(31,0));
                           
                                        Debug.Log("printing metronome info!");
                                        Debug.Log("measure count = " + metronomeInfo[0]);
                                        Debug.Log("downbeatCount = " + metronomeInfo[1]);
                                        Debug.Log("tickCount = " + metronomeInfo[2]);
                                        Debug.Log("isDownBeat = " + metronomeInfo[3]);
                                        
                            
                }
                else if(isDownBeat == 1 && (downbeatCount == 1 || downbeatCount == 3))
                         Instantiate(objects[1], new Vector2(objects[1].transform.position.x,1),Quaternion.identity).transform.Translate(new Vector2(31,0));    
                        

                else if(measureCount >=  20 && isDownBeat == 0 && ((downbeatCount == 0 && (tickCount == 2 || tickCount == 6 )) || (downbeatCount == 1 && (tickCount == 4)) || (downbeatCount == 2 && (tickCount == 6 )) || (downbeatCount == 3 && (tickCount == 4 )))){
                         Instantiate(objects[2], new Vector2(objects[2].transform.position.x,3),Quaternion.identity).transform.Translate(new Vector2(31,0));

                        Debug.Log("dsp: " + AudioSettings.dspTime);
                }
                else if(measureCount >= 28 && downbeatCount == 2 && tickCount == 3)   
                        Instantiate(objects[3], new Vector2(objects[3].transform.position.x,-4),Quaternion.identity).transform.Translate(new Vector2(31,0));
             

                }
                

        }
	
	// Update is called once per frame
}
