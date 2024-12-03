using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioSource background, heartbeat;
	public CircleCollider2D heartbeatZone01,heartbeatZone02,heartbeatZone03,heartbeatZone04,heartbeatZone05;
	//public float sliderValue = 0.0f;
	// Use this for initialization
	void Start () {
		background.volume = 0.5f;
		heartbeat.volume = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other == heartbeatZone01) {
			//Debug.Log ("Touch enemy");
			background.volume = 0.0f;
			heartbeat.volume = 0.5f;
		} else if (other == heartbeatZone02) {
			//Debug.Log ("Touch enemy 01");
			background.volume = 0.0f;
			heartbeat.volume = 0.5f;
		} else if (other == heartbeatZone03) {
			//Debug.Log ("Touch enemy 02");
			background.volume = 0.0f;
			heartbeat.volume = 0.5f;
		} else if (other == heartbeatZone04) {
			//Debug.Log ("Touch enemy 03");
			background.volume = 0.0f;
			heartbeat.volume = 0.5f;
		} else if (other == heartbeatZone05) {
			//Debug.Log ("Touch enemy 04");
			background.volume = 0.0f;
			heartbeat.volume = 0.5f;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other == heartbeatZone01) {
			background.volume = 0.5f;
			heartbeat.volume = 0.0f;
		} else if (other == heartbeatZone02) {
			background.volume = 0.5f;
			heartbeat.volume = 0.0f;
		} else if (other == heartbeatZone03) {
			background.volume = 0.5f;
			heartbeat.volume = 0.0f;
		} else if (other == heartbeatZone04) {
			background.volume = 0.5f;
			heartbeat.volume = 0.0f;
		} else if (other == heartbeatZone05) {
			background.volume = 0.5f;
			heartbeat.volume = 0.0f;
		}
	}
}

