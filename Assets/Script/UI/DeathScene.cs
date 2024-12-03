using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
   static string sceneName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void replayLevel()
    {
		sceneName = PlayerPrefs.GetString("lastDeathScene");
        if (sceneName == "Level 1")
        {
            //l  sceneName = "Level2";
            //  PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Level 1");
        }

        if (sceneName == "Level2")
        {
          //l  sceneName = "Level2";
          //  PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Level2");
        }
		if (sceneName == "FinalBossLevel")
		{
			//l  sceneName = "Level2";
			//  PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
			SceneManager.LoadScene("FinalBossLevel");
		}
        else if (sceneName == "Level 3")
        {
          //  PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("sceneName");
        }
        else if (sceneName == "Level 4")
        { 
          //  PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(sceneName);
        }
    }
}
