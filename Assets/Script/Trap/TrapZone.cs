using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapZone : MonoBehaviour {

	// SpriteRenderer trap1,trap2,trap3,trap4,trap5,trap6,trap7;
	public GameObject shard01,shard02,shard03,shard04,shard05;
	public GameObject trap01,trap03,trap04,trap05,trap06,trap07,trap08;
	private Animator animTrap01,animTrap02,animTrap03,animTrap04,animTrap05,animTrap06,animTrap07,animTrap08;

	// Use this for initialization
	void Start () {
		animTrap01 = trap01.GetComponent<Animator> ();
		animTrap03 = trap03.GetComponent<Animator> ();
		animTrap04 = trap04.GetComponent<Animator> ();
		animTrap05 = trap05.GetComponent<Animator> ();
		animTrap06 = trap06.GetComponent<Animator> ();
		animTrap07 = trap07.GetComponent<Animator> ();
		animTrap08 = trap08.GetComponent<Animator> ();

		trap01.SetActive (false);
		trap03.SetActive (false);
		trap04.SetActive (false);
		trap05.SetActive (false);
		trap06.SetActive (false);
		trap07.SetActive (false);
		trap08.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (!shard01.activeSelf) {
			trap01.SetActive (true);
			animTrap01.SetBool ("isObtain01", true);
			animTrap01.speed = 3;
		} 

		if (!shard02.activeSelf) {
			trap03.SetActive (true);
			animTrap03.SetBool ("isObtain02", true);
		}

		if (!shard03.activeSelf) {
			trap04.SetActive (true);
			animTrap04.SetBool ("isObtain03", true);
		} 

		if (!shard04.activeSelf) {
			trap06.SetActive (true);
			trap07.SetActive (true);
			trap08.SetActive (true);
			animTrap06.SetBool ("isObtain", true);
			animTrap07.SetBool ("isObtain04", true);
			animTrap08.SetBool ("isObtain05", true);
		} 
		if (!shard05.activeSelf) {
			trap05.SetActive (true);
			animTrap05.SetBool ("isObtain06", true);
		}
	}


}
