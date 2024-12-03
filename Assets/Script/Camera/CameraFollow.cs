using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject mainCam;
	public Transform player;
	private GameObject boundaryVerti, boundaryVerti2,boundaryHori, boundaryHori2;

	void Start()
	{
		boundaryVerti = GameObject.FindGameObjectWithTag("boundaryV");
		boundaryVerti2 = GameObject.FindGameObjectWithTag("boundaryV2");
		boundaryHori = GameObject.FindGameObjectWithTag("boundaryH");
		boundaryHori2 = GameObject.FindGameObjectWithTag("boundaryH2");
		transform.position = player.position;
	}

	void Update()
	{
		if (player)
		{
			if ((boundaryVerti.activeSelf || boundaryVerti2.activeSelf) && (!boundaryHori.activeSelf && !boundaryHori2.activeSelf))
			{
				//Debug.Log("Vertical Boundary in CameraFollow is true");
				transform.position = new Vector3 (transform.position.x, Mathf.Lerp (transform.position.y,player.position.y, 0.2f), -10);
			}
			else if ((boundaryHori.activeSelf || boundaryHori2.activeSelf) && (!boundaryVerti.activeSelf && !boundaryVerti2.activeSelf))
			{
				//Debug.Log("Horizontal Boundary  in CameraFollow is true");
				transform.position = new Vector3 (Mathf.Lerp (transform.position.x,player.position.x, 0.2f),transform.position.y, -10);
			}
			else if ((boundaryHori.activeSelf || boundaryHori2.activeSelf) && (boundaryVerti.activeSelf || boundaryVerti2.activeSelf)) 
			{
				//Debug.Log("Horizontal & Vertical Boundary in CameraFollow is true");
//				transform.position = Vector3.Lerp(transform.position, player.position, 0.2f) + new Vector3(0, 0, -10);
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, player.position, 0.2f) + new Vector3(0, 0, -10);
			}
		}
	}
}
