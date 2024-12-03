// This script will disable the camera component of Main Camera gameobject, PlayerControl.cs of Player gameobject and enable camera component of Map Intro gameobject for 5 seconds.
// After that, it will go back to normal game state
// Purpose: to show the player the map for 5 seconds before the game start

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraIntro : MonoBehaviour {
	
	private GameObject player;
	public Camera mapIntroCam,mainCam; 
	bool isTime, isClose;
	Scene currentScene;
	public Animator topAnim, bottomAnim;

	IEnumerator WaitAfterClose()
	{
		yield return new WaitForSeconds (2.0f);
		isClose = true;
	}
		
	IEnumerator Waiting()
	{
		yield return new WaitForSeconds (3.0f);
		//Debug.Log ("5 seconds passed");
		isTime = true;
	}

	void Start ()
	{
		isTime = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		currentScene = SceneManager.GetActiveScene ();
		if (currentScene.isLoaded) {
			//Debug.Log ("Scence Loaded!");
			player.GetComponent<PlayerControl> ().enabled = false;
			player.GetComponent<ShowMap> ().enabled = false;
			if (mainCam.enabled) {
				//Debug.Log ("Camera Switcher: Main Camera is active");
				mainCam.enabled = !mainCam.enabled;
				mapIntroCam.enabled = true;
			}
		}
	}	

	// Update is called once per frame
	void Update ()
	{
		if (mapIntroCam.enabled) {
			//Debug.Log ("Camera Switcher: Map Intro is active");
			StartCoroutine (WaitAfterClose ());
			if (isClose == true) {
				
				ClosePanels ();
				StartCoroutine (Waiting ());
				if (isTime == true) {
					mainCam.enabled = true;
					mapIntroCam.enabled = false;
					if (!mapIntroCam.enabled) {
						OpenPanels ();
					}
					player.GetComponent<PlayerControl> ().enabled = true;
					player.GetComponent<ShowMap> ().enabled = true;
				}
			}

		}
	}

	void ClosePanels()
	{
		topAnim.SetBool ("isMapOn", true);
		bottomAnim.SetBool ("isMapOn", true);
	}

	void OpenPanels()
	{
		topAnim.SetBool ("isMapOn", false);
		bottomAnim.SetBool ("isMapOn", false);
	}
}
