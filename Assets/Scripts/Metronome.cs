using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour
{
	 public GameObject[] objects;
    public double bpm = 109.0F;

    double nextTick = 0.0F; // The next tick in dspTime
    double sampleRate = 0.0F; 
	bool isStarted;
    private int tickCount;
    private int measureCount;
    private int downbeatCount;
    private int isDownBeat;

    private int[] metronomeInfo;

    bool ticked = false;
	private AudioSource aud;
	 private GameObject goPlayer;

    void Start() {
        tickCount = 0;
        measureCount = 0;
        downbeatCount = 1;
        isDownBeat = 1;
        metronomeInfo = new int[4];
        metronomeInfo[0] = measureCount;
        metronomeInfo[1] = downbeatCount;
        metronomeInfo[2] = tickCount;
        metronomeInfo[3] = isDownBeat;
        double startTick = AudioSettings.dspTime ;
        //Debug.Log("Start tick : " + startTick);
        sampleRate = AudioSettings.outputSampleRate;
		isStarted = false;
        nextTick = startTick + (60.0f / bpm); //1 beat için geçmesi gereken saniye sarkı offbeast baslayınca 30/bpm ekledık
        //Debug.Log("Next tick : " + nextTick);
        
		//aud = goPlayer.audio;
    }

    void LateUpdate() {
        if ( !ticked && nextTick >= (AudioSettings.dspTime) ) {
            ticked = true;
            //Debug.Log("Broadcasting OnTick!!");

            updateMetronomeInfo();
            BroadcastMessage( "OnTick" , metronomeInfo);

            tickCount = (tickCount + 1) % 4;
            if(tickCount  == 0){
                downbeatCount = (downbeatCount + 1) % 4;
                isDownBeat = 1;
                
            }
            else{
                isDownBeat = 0;
            }

            if(downbeatCount == 0 && isDownBeat == 1){
                measureCount++;
            }
        }
    }

    // Just an example OnTick here
    void OnTick() {
        //Debug.Log( "Tick" );
        
		
		if(!isStarted && !GetComponent<AudioSource>().isPlaying){

             AudioSource music = FindObjectOfType<AudioSource>();

            music.PlayDelayed(1.50f);
				
				//Debug.Log("Start Playing!");
                isStarted = true;
		}
         
    }

    void FixedUpdate() {

//find nextTick
        double timePerTick;
  
            timePerTick = 15f / bpm;
        double dspTime = AudioSettings.dspTime;

        while ( (dspTime )  >= nextTick) {
			
            ticked = false;
            nextTick += timePerTick;
            
        }

    }

    void updateMetronomeInfo(){
          metronomeInfo[0] = measureCount;
          metronomeInfo[1] = downbeatCount;
          metronomeInfo[2] = tickCount;
          metronomeInfo[3] = isDownBeat;
    }
}