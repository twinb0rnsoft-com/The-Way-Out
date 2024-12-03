using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrapControlA : MonoBehaviour {

	private BoxCollider2D boxcollider; 
	public  BoxCollider2D wallDamage;
	private Transform playerTransform;
	public GameObject soulShard, player;
	public Animator anim;
	float time = 0.0f;
	float timeMax = 5.0f;

	// Use this for initialization
	void Start () 
	{
		wallDamage.enabled = false;
		boxcollider = GetComponent<BoxCollider2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
        soulShard = GameObject.FindGameObjectWithTag("SoulShard");
        playerTransform = player.GetComponent<Transform> ();
		//animate ["TrapSoulSWall1_Close"].speed = 0.2f;
	}

	// Update is called once per frame
	void Update () 
	{
		ColliderManager ();
		CheckSoulShard ();
	}

	void ColliderManager()
	{
		if (boxcollider.bounds.min.x <= playerTransform.position.x && playerTransform.position.x <= boxcollider.bounds.max.x &&
		    boxcollider.bounds.min.y <= playerTransform.position.y && playerTransform.position.y <= boxcollider.bounds.max.y) {
			//Debug.Log ("Player is in Trap Zone");
		} else {
			//Debug.Log ("Player is outside Trap Zone");
		}
	}

	void CheckSoulShard()
	{
		if (soulShard.activeSelf) {
			//Debug.Log ("Soul Shard is in Trap Zone");
		} else if (!soulShard.activeSelf) 
		{
			//Debug.Log ("Soul Shard is outside Trap Zone");
			anim.SetBool ("isShardObtain", true);
			wallDamage.enabled = true;
			if ( wallDamage.bounds.min.x <= playerTransform.position.x && playerTransform.position.x <= wallDamage.bounds.max.x &&
			    wallDamage.bounds.min.y <= playerTransform.position.y && playerTransform.position.y <= wallDamage.bounds.max.y) {
				//Debug.Log ("Player is Damaged!!!");
				GetComponent<Health>().currHealth -= 50;
				GetComponent<Health>().displayHealth();
			}
		}
	}
}
