using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMainMenu : MonoBehaviour {

    public bool paused;
	// Use this for initialization
	void Start () {
        //paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //Application.LoadLevel(sceneName);
    }
   public void quitGame()
    {
        Application.Quit();
    }
    public void resumeGame()
    {

    }
}
