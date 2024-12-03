using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour {
    public Text prologue;
    public float speed = 0.05f;

    string intro = "Matt, a young boy, is under controlled by a dream demon named Somdae.\nHe is trapped in his deepest nightmare and unables to wake up.\nSomdae turns Matt's fear into monsters and dream into a maze.\nThe demon breaks Matt's soul into small pieces and scatters it around the maze.\nHe also poisons Matt, so his health decreases every second.\nNow, Matt has to find all his soul shards and escapes the maze before his health runs out.\nIn order to unlock a door to advance to the next level, Matt has to find all his soul shards.\nWhile he is trapped in the maze, he can collect dream tokens to buy consumables at the end of a level.\nWhen Matt finishes all levels, he will face Somdae.\nWhen he defeats Somdae, Matt will wake up from this nightmare.\n  ";
    // Use this for initialization
    void Start () {
        StartCoroutine(display());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator display()
    {
        prologue.text = "";
        foreach(char letter in intro.ToCharArray())
        {
            prologue.text += letter;
            yield return new WaitForSeconds(speed);
        }


    }
}
