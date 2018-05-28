using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour
{
	 public GameObject[] objects;
    public double bpm = 109.0F;

    double nextTick = 0.0F; // The next tick in dspTime
    double sampleRate = 0.0F; 
	bool isStarted;
    bool ticked = false;
	private AudioSource aud;
	 private GameObject goPlayer;

    void Start() {
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
		isStarted = false;
        nextTick = startTick + (60.0 / bpm);
		//aud = goPlayer.audio;
    }

    void LateUpdate() {
        if ( !ticked && nextTick >= AudioSettings.dspTime ) {
            ticked = true;
            Debug.Log("Broadcasting OnTick!!");
            BroadcastMessage( "OnTick" );
        }
    }

    // Just an example OnTick here
    void OnTick() {
        Debug.Log( "Tick" );
        
		
		if(!isStarted && !GetComponent<AudioSource>().isPlaying){
				GetComponent<AudioSource>().Play();
				Debug.Log("Start Playing!");
                isStarted = true;
		}
         
    }

    void FixedUpdate() {

        double timePerTick;
        if(!isStarted)
            timePerTick = 60.0f / bpm;
        else
            timePerTick = 7.5f / bpm;
        double dspTime = AudioSettings.dspTime;

        while ( dspTime >= nextTick ) {
			
            ticked = false;
            nextTick += timePerTick;
            
        }

    }
}