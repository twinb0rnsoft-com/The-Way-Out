using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManagerVertical : MonoBehaviour {

	private BoxCollider2D managerBox;
	private Transform player;
	public GameObject boundaryVert;

	void Start()
	{
		managerBox = GetComponent<BoxCollider2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void Update()
	{
		ManagerBoundary ();
	}

	void ManagerBoundary()
	{
		if (managerBox.bounds.min.x <= player.position.x && player.position.x < managerBox.bounds.max.x &&
			managerBox.bounds.min.y <= player.position.y && player.position.y < managerBox.bounds.max.y) {
			boundaryVert.SetActive (true);
			//Debug.Log ("Boundary is Active");
		} else {
			boundaryVert.SetActive (false);
		}
	}
}
