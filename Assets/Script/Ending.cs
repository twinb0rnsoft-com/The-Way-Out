using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {
    public Text displayText;
    public float speed = 0.05f;

    string ending = "After Matt defeats Somdae, he was able to wake up.\n Afterward, he rarely has nightmare.\n He gains more confidence and skills in real life.\n ";

    // Use this for initialization
    void Start()
    {
        StartCoroutine(display());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator display()
    {
        displayText.text = "";
        foreach (char letter in ending.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(speed);
        }


    }
}
