using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollide : MonoBehaviour {

	public GameObject trap1,trap2,trap3,trap4,trap5,trap6,trap7,trap8;
	public int trapDamage;
	public AudioSource DamageSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D trapColl)
	{
		if (trapColl == trap1.GetComponent<BoxCollider2D> ()) {
			//
			DamageSound.GetComponent<AudioSource>().Play();
			GetComponent<Health> ().currHealth -= trapDamage;
		} else if (trapColl == trap2.GetComponent<BoxCollider2D> ()) {
			//
			DamageSound.GetComponent<AudioSource>().Play();
			GetComponent<Health> ().currHealth -= trapDamage;
		} else if (trapColl == trap3.GetComponent<BoxCollider2D> ()) {
			//
			DamageSound.GetComponent<AudioSource>().Play();
			GetComponent<Health> ().currHealth -= trapDamage;
		} else if (trapColl == trap4.GetComponent<BoxCollider2D> ()) {
			//
			DamageSound.GetComponent<AudioSource>().Play();
			GetComponent<Health> ().currHealth -= trapDamage;
		} else if (trapColl == trap5.GetComponent<BoxCollider2D> ()) {
			//
			DamageSound.GetComponent<AudioSource>().Play();
			GetComponent<Health> ().currHealth -= 100;
		} else if (trapColl == trap6.GetComponent<BoxCollider2D> ()) {
			//
			DamageSound.GetComponent<AudioSource>().Play();
			GetComponent<Health> ().currHealth -= trapDamage;
		} else if (trapColl == trap7.GetComponent<BoxCollider2D> ()) {
			//
			DamageSound.GetComponent<AudioSource>().Play();
			GetComponent<Health> ().currHealth -= trapDamage;
		} else if (trapColl == trap8.GetComponent<BoxCollider2D> ()) {
			//
			DamageSound.GetComponent<AudioSource>().Play();
			GetComponent<Health> ().currHealth -= trapDamage;
		}
	}
}
