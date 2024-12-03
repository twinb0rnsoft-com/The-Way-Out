using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingControl : MonoBehaviour {

	public BoxCollider2D doorClosedTrigger, doorOpenedTrigger;
	private Transform player;
	public Sprite[] doorSprites;

	// Use this for initialization
	void Start () 
	{
		//Instantiate (gameObject);
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		//doorSprites = Resources.LoadAll<Sprite> ("hidedoorlev2");
		Debug.Log (doorSprites.Length);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Check if Player is inside the  first BoxCollider2D. If so, change the sprite image of that object
		if (doorClosedTrigger.bounds.min.x <= player.position.x && player.position.x < doorClosedTrigger.bounds.max.x &&
		    doorClosedTrigger.bounds.min.y <= player.position.y && player.position.y < doorClosedTrigger.bounds.max.y) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = doorSprites [1];
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = doorSprites [0];
		}

//		// Check if Player is inside the  second BoxCollider2D. If so, disable the Player's sprite renderer (hide Player)
//		if (doorOpenedTrigger.bounds.min.x <= player.position.x && player.position.x < doorOpenedTrigger.bounds.max.x &&
//		    doorOpenedTrigger.bounds.min.y <= player.position.y && player.position.y < doorOpenedTrigger.bounds.max.y) {
//
//			// Disable the Player's SpriteRenderer
//			if (player.GetComponent<SpriteRenderer> ().enabled == true) {
//				player.GetComponent<SpriteRenderer> ().enabled = false;
//				if (player.GetComponent<SpriteRenderer> ().enabled == false) {
//					Debug.Log ("Player Enter Door");
//				}
//			}
//		} else {
//			if (player.GetComponent<SpriteRenderer> ().enabled == false) {
//				player.GetComponent<SpriteRenderer> ().enabled = true;
//			}
//		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		other = doorOpenedTrigger;
		if (player.GetComponent<SpriteRenderer> ().enabled == true) {
			player.GetComponent<SpriteRenderer> ().enabled = false;
			if (player.GetComponent<SpriteRenderer> ().enabled == false) {
				Debug.Log ("Player Enter Door");
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		other = doorOpenedTrigger;
		if (player.GetComponent<SpriteRenderer> ().enabled == false) {
			player.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
