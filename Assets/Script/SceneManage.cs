using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {
    static string sceneName;

    // Use this for initialization
    void Start () {
        sceneName = PlayerPrefs.GetString("lastLevel");

    }

    // Update is called once per frame
    void Update () {
      //  changeLevel();
    }
    
    public void changeLevel()
    {

        if (sceneName == "Level 1")
        {
           PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("ShopV2");
        }
        if (sceneName == "Level2")
        {
           PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("ShopV2");
        }
        /*
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("ShopV2");
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("ShopV2");
        }
        */

        /*
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 3"))
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("ShopV2");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 4"))
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("ShopV2");
        }
        */
    }
 
    //change scene
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
