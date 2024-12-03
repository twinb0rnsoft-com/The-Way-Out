using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHit : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D trapColl)
	{
		Debug.Log ("Spike Hit Player!");
		trapColl = player.GetComponent<BoxCollider2D> ();
		GetComponent<Health> ().decreaseHealth = 20;
		GetComponent<Health> ().displayHealth ();
	}
}
