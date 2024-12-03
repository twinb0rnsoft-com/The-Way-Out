using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManagerHorizontal : MonoBehaviour {

	private BoxCollider2D managerBoxB;
	private Transform player;
	public GameObject boundaryHori;
	CameraFollow CamSett;

	void Start()
	{
		managerBoxB = GetComponent<BoxCollider2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void Update()
	{
		ManagerBoundary ();
	}

	void ManagerBoundary()
	{
		if (managerBoxB.bounds.min.x <= player.position.x && player.position.x < managerBoxB.bounds.max.x &&
			managerBoxB.bounds.min.y <= player.position.y && player.position.y < managerBoxB.bounds.max.y) {
			boundaryHori.SetActive (true);
			//Debug.Log ("BoundaryTwo is Active");
		} else {
			boundaryHori.SetActive (false);
		}
	}
}
