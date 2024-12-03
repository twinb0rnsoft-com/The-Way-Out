using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueZoneTrigger : MonoBehaviour {

	public GameObject trigger1, trigger2, trigger3, trigger4,trigger5,trigger6,trigger7;
	private GameObject soulShard;
	[HideInInspector]
	public DialogueTrigger dialogueTrig;
	// Use this for initialization
	void Start () {
		trigger1.GetComponent<BoxCollider2D> ().enabled = true;
		trigger2.GetComponent<BoxCollider2D> ().enabled = true;
		trigger3.GetComponent<BoxCollider2D> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other == trigger1.GetComponent<BoxCollider2D> ()) {
			Debug.Log ("Inside Collider");
			trigger1.GetComponent<DialogueTrigger> ().TriggerDialogue ();
		} else if (other == trigger2.GetComponent<BoxCollider2D> ()) {
			trigger2.GetComponent<DialogueTrigger> ().TriggerDialogue ();
		} else if (other == trigger3.GetComponent<BoxCollider2D> ()) {
			trigger3.GetComponent<DialogueTrigger> ().TriggerDialogue ();
		} else if (other == trigger4.GetComponent<BoxCollider2D> ()) {
			trigger4.GetComponent<DialogueTrigger> ().TriggerDialogue ();
		} else if (other.gameObject.CompareTag ("SoulShard")) {
			trigger5.GetComponent<DialogueTrigger> ().TriggerDialogue ();
		} else if (other == trigger6.GetComponent<BoxCollider2D> ()) {
			trigger6.GetComponent<DialogueTrigger> ().TriggerDialogue ();
		} else if (other == trigger7.GetComponent<BoxCollider2D> ()) {
			trigger7.GetComponent<DialogueTrigger> ().TriggerDialogue ();
			}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other == trigger1.GetComponent<BoxCollider2D> ()) {
			trigger1.GetComponent<BoxCollider2D> ().enabled = false;
		} else if (other == trigger2.GetComponent<BoxCollider2D> ()) {
			trigger2.GetComponent<BoxCollider2D> ().enabled = false;
		} else if (other == trigger3.GetComponent<BoxCollider2D> ()) {
			trigger3.GetComponent<BoxCollider2D> ().enabled = false;
		}else if (other == trigger4.GetComponent<BoxCollider2D> ()) {
			trigger4.GetComponent<BoxCollider2D> ().enabled = false;
		}else if (other == trigger6.GetComponent<BoxCollider2D> ()) {
			trigger6.GetComponent<BoxCollider2D> ().enabled = false;
		}else if (other == trigger7.GetComponent<BoxCollider2D> ()) {
			trigger7.GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
		
}
