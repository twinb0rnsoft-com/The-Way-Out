using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

	public enum Direction {Up,Down,Left,Right};
	public Direction playerDir;
	public Animator animFront;
	public float animationSpeed;
	private bool isMoveDown;

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2.0f);
	}
	// Use this for initialization
	void Start () {
		animFront = GetComponent<Animator>();
		isMoveDown = false;
		animFront.speed = animationSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		// Player Movements
		Move ();
		Run ();

		// Player Attack
		if (gameObject.GetComponent<Weapon> ().weaponInventory [0] == true) {
			AttackAxe ();
		} else if (gameObject.GetComponent<Weapon> ().weaponInventory [1] == true) {
			AttackSword ();
		}
	}

	void Move()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			animFront.SetBool ("isUp", true);
			playerDir = Direction.Up;
			//Debug.Log (playerDir);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			animFront.SetBool ("isDown", true);
			playerDir = Direction.Down;
			//Debug.Log (playerDir);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			animFront.SetBool ("isLeft", true);
			playerDir = Direction.Left;
			//Wait ();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			animFront.SetBool ("isRight", true);
			playerDir = Direction.Right;
			//Debug.Log (playerDir);
		} else {
			animFront.SetBool ("isUp", false);
			animFront.SetBool ("isDown", false);
			animFront.SetBool ("isLeft", false);
			animFront.SetBool ("isRight", false);
		}
	}

	 void AttackAxe()
	{
		if (Input.GetKeyDown(KeyCode.X) && playerDir == Direction.Up) {
			animFront.SetBool ("isBackAxe", true);
		} else {
			animFront.SetBool ("isBackAxe", false);
		}

		if (Input.GetKeyDown(KeyCode.X) && playerDir == Direction.Down) {
			animFront.SetBool ("isFrontAxe", true);
		} else {
			animFront.SetBool ("isFrontAxe", false);
		}

		if (Input.GetKeyDown(KeyCode.X) && playerDir == Direction.Left) {
			animFront.SetBool ("isLeftAxe", true);
		} else {
			animFront.SetBool ("isLeftAxe", false);
		}

		if (Input.GetKeyDown(KeyCode.X) && playerDir == Direction.Right) {
			animFront.SetBool ("isRightAxe", true);
		} else {
			animFront.SetBool ("isRightAxe", false);
		}
	}

	void AttackSword()
	{
		if (Input.GetKeyDown(KeyCode.X) && playerDir == Direction.Up) {
			animFront.SetBool ("isBackSword", true);
		} else {
			animFront.SetBool ("isBackSword", false);
		}

		if (Input.GetKeyDown(KeyCode.X) && playerDir == Direction.Down) {
			animFront.SetBool ("isFrontSword", true);
		} else {
			animFront.SetBool ("isFrontSword", false);
		}

		if (Input.GetKeyDown(KeyCode.X) && playerDir == Direction.Left) {
			animFront.SetBool ("isLeftSword", true);
		} else {
			animFront.SetBool ("isLeftSword", false);
		}

		if (Input.GetKeyDown(KeyCode.X) && playerDir == Direction.Right) {
			animFront.SetBool ("isRightSword", true);
		} else {
			animFront.SetBool ("isRightSword", false);
		}
	}


	void Run()
	{
		if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.Z)) {
			animFront.SetBool ("isLeftFast", true);
		} else {
			animFront.SetBool ("isLeftFast", false);
		}

		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.Z)) {
			animFront.SetBool ("isUpFast", true);
		} else {
			animFront.SetBool ("isUpFast", false);
		}

		if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey (KeyCode.Z)) {
			animFront.SetBool ("isDownFast", true);
		} else {
			animFront.SetBool ("isDownFast", false);
		}

		if (Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.Z)) {
			animFront.SetBool ("isRightFast", true);
		} else {
			animFront.SetBool ("isRightFast", false);
		}
	}
} 