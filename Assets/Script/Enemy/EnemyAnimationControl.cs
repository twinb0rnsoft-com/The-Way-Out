using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour {

	public Animator enemyAnim;
	float oldPosX, oldPosY;
	// Use this for initialization
	void Start () {
		oldPosX = transform.position.x;
		oldPosY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (oldPosX < transform.position.x) {
			enemyAnim.SetBool ("isWalkRight", true);
			//Debug.Log("Right");
		} else if (oldPosX > transform.position.x) {
			enemyAnim.SetBool ("isWalkLeft", true);
			//Debug.Log("Left");
		} else if (oldPosY < transform.position.y) {
			//enemyAnim.SetBool ("isWalkUp", true);
			Debug.Log("Up");
		} else if (oldPosY > transform.position.y) {
			//enemyAnim.SetBool ("isWalkDown", true);
			Debug.Log("Down");
		} else if (oldPosX > transform.position.x && oldPosY > transform.position.y) {
			//enemyAnim.SetBool ("isWalkUp", true);
			Debug.Log("Up Left or Up Right");
		} else 
		{
			enemyAnim.SetBool ("isWalkRight", false);
			enemyAnim.SetBool ("isWalkLeft", false);
//			enemyAnim.SetBool ("isWalkUp", false);
//			enemyAnim.SetBool ("isWalkDown", false);
		}
			

		oldPosX = transform.position.x;
		oldPosY = transform.position.y;
	}
}
