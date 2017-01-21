using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour {

    private WaveMaker myWM;

	// Use this for initialization
	void Start () {
        myWM = GameObject.Find("Waveform").GetComponent<WaveMaker>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        int whichToFollow = (99 - (int)transform.position.x) / 2;
        //Debug.Log(whichToFollow);
        transform.position = new Vector3(transform.position.x, myWM.points[whichToFollow] + 5, 0);
	}
}
