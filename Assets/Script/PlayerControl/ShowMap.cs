using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMap : MonoBehaviour {

	// Initialize
	bool isMapOpen;
	public Camera characterCamera;
	public Camera mapCamera;

	// Process
	
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		ShowingMap();
	}

	void ShowingMap()
	{
		if (Input.GetKey (KeyCode.H)) {
			mapCamera.enabled = true;
			characterCamera.enabled = false;
			gameObject.GetComponent<PlayerControl> ().enabled = false;
		} else {
			mapCamera.enabled = false;
			characterCamera.enabled = true;
			gameObject.GetComponent<PlayerControl> ().enabled = true;
		}
	}
}
