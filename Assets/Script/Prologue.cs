using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour {

    public Text intro;
    public string[] lines;
    public float speed = 0.15f;


    int stringIndex = 0;
    int characterIndex = 0;
    // Use this for initialization
    void Start () {
        StartCoroutine(play());
    }

    // Update is called once per frame

   
    IEnumerator play()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(speed);
            if (stringIndex >= 12)
            {
                break;
            }
            else if (characterIndex > lines[stringIndex].Length)
            {
                continue;
            }
            intro.text = lines[stringIndex].Substring(0, characterIndex);
            characterIndex++;
    
       }
    }
    void Update()
    {
        if (stringIndex == lines.Length -1)
        {
            // if (characterIndex > lines[stringIndex].Length )
            //   {
            if (stringIndex >= 12)
            {
                // intro.text = "";
                 characterIndex = 0;
                 stringIndex = 0;
              //  StopCoroutine(play());
                
            }
            characterIndex = lines[stringIndex].Length;
       
        }
    
         if (characterIndex >= lines[stringIndex].Length)
           {
              stringIndex++;
               characterIndex = 0;
            //   StartCoroutine(timer());

        }
            StopCoroutine(play());

       


    }

   IEnumerator playIntro()
   {

       intro.text = "Matt, a young boy, is under controlled by a dream demon named Somdae. ";
       yield return new WaitForSeconds(10);
       intro.text = "He is trapped in his deepest nightmare and unables to wake up.";
       yield return new WaitForSeconds(15);

       intro.text = "Somdae turns Matt's fear into monsters and dream into a maze.";
       yield return new WaitForSeconds(5);
       intro.text = "The demon breaks Matt's soul into small pieces and scatters it around the maze.";
       yield return new WaitForSeconds(5);
       intro.text = "He also poisons Matt, so his health decreases every second.";
       yield return new WaitForSeconds(5);
       intro.text = "Now, Matt has to find all his soul shards and escapes the maze before his health runs out.";
       yield return new WaitForSeconds(5);
       intro.text = "In order to unlock a door to advance to the next level, ";
       yield return new WaitForSeconds(5);
       intro.text = "Matt has to find all his soul shards.";
       yield return new WaitForSeconds(5);
       intro.text = "While he is trapped in the maze, he can collect dream tokens to buy consumables at the end of a level.";
       yield return new WaitForSeconds(5);
       intro.text = "When Matt finishes all levels, he will face Somdae.";
       yield return new WaitForSeconds(5);
       intro.text = "When he defeats Somdae, Matt will wake up from this nightmare.";
       yield return new WaitForSeconds(5);
       intro.text = "";

  

} 
   
    
}
