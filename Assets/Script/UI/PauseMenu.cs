using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	// Pause Menu Variable Declaration
    public  bool paused = false;

    public GUISkin customSkin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetKeyDown(KeyCode.P))
        {
            paused = togglePause();

        }
	}

	void OnGUI()
    {
        if (paused)
        {
            GUI.skin = customSkin;
			//Screen.width/2  Screen.height/2)
            //center button and text label on screen when paused 
			GUI.Box(new Rect(455, 50, 250, 450), "This is a box");
            GUI.backgroundColor = Color.cyan;
            GUI.contentColor = Color.white;
            var centeredLabel = GUI.skin.GetStyle("Label");
            centeredLabel.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(500,80,150,150), "Game Paused", centeredLabel);

            //resume game button
            if ((GUI.Button(new Rect(500, 250, 150, 50), ("Resume"))))
            {
                paused = togglePause();

            }
            //exit to main screen button
			if ((GUI.Button(new Rect(500, 300, 150, 50), ("Main Menu"))))
			{
				SceneManager.LoadScene("GameMain");

			}
            //restart level button
            if ((GUI.Button(new Rect(500, 350, 150, 50), ("Restart"))))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
                Debug.Log("Level restarts");
            }
        }
    }

    //pause game
    public bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            GetComponent<Health>().decreaseHealth = 0.011f;

            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            GetComponent<Health>().decreaseHealth = 0f;


            return (true);
        }
    }
}
