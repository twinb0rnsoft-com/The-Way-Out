using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText, dialogueText;
	private Queue<string> sentences;
	public Animator anim;
	public GameObject DialogBox;


	void Start () {
		sentences = new Queue<string> ();
		DialogBox.SetActive (false);
	}

	public void StartDialogue(Dialogue dialogue)
	{
		Debug.Log ("Starting conversation with " + dialogue.name);
		DialogBox.SetActive (true);
		//anim.SetBool ("isOpen", true);
		nameText.text = dialogue.name;
		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) 
		{
			DialogBox.SetActive (false);
			//anim.SetBool ("isOpen", false);
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
	}
	void EndDialogue()
	{
		Debug.Log ("End of conversation");
	}
}
