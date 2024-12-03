using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShopV2 : MonoBehaviour {

    public static ShopV2 shop;

    public static PlayerControl p1 = new PlayerControl();

    static int  healthPotion = 0;
    static int healthBlock = 0;
    static int speedPotion = 0;
    //return token count from dreamToken script
    private static int dreamToken = DreamTokenCollecting.returnTokenCount();

    // order: health potion, god Speed, health Block
    private static int[] consumableCost = new int[] { 5, 7, 10 };
    public static bool[] consumableEnabled = new bool[] { false, false, false};
    public int scenelvl;

    //pass info
    public static int index;
    public static string consumableName;

    public static ShopPopUpWeapon pop1 = new ShopPopUpWeapon();

    public Text amount;
    public Text healthDescription;
    public Text speedDescription;
    public Text healthBlockDescription;

    // Use this for initialization
    void Start () {
        shop = this;

        amount.text = dreamToken.ToString();
        healthDescription.text = "Description: Prevents health decrease for 20 seconds when use\nDream Tokens: 5";
        speedDescription.text = "Description: Prevents stamina from draining when running for 10 seconds\nDream Tokens: 7";
        healthBlockDescription.text = "Description: Protects player from everything for 20 seconds\nDream Tokens: 10";

    }

    // Update is called once per frame
    void Update () {
        // updateToken();

    }

    public void buyHealthPotion()
    {
        //buy health potion
        if (dreamToken < consumableCost[0])
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= consumableCost[0];
            index = 0;
            consumableName = "Health Potion";
            changeScene("ShopPopUp");
            Debug.Log("Health Potion purchased");
            healthPotion++;
            consumableEnabled[0] = true;
        }
    }
    public void buySpeedPotion()
    {
        //buy god speed potion
        if (dreamToken < consumableCost[1])
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= consumableCost[1];
            index = 1;
            consumableName = "Speed Potion";
            changeScene("ShopPopUp");
            Debug.Log("Speed Potion purchased");
            speedPotion++;
            consumableEnabled[1] = true;
        }
    }

    public void buyHealthBlock()
    {

        //buy health block
        if (dreamToken < consumableCost[2])
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= consumableCost[2];
            index = 2;
            consumableName = "Health Block Potion";
            changeScene("ShopPopUp");
            Debug.Log("Health Block Potion purchased");
            consumableEnabled[2] = true;
            healthBlock++;
        }
 
}
    

    public void changeScene(string name)
    {
        SceneManager.LoadScene(name);

    }
   
    //change scene
    public void changeSceneLevel()
    {
        string sceneName = PlayerPrefs.GetString("lastLevel");

      //  scenelvl = GetComponent<SceneManage>().returnSceneLevel();

        if (sceneName == "Level 1")
        {
            SceneManager.LoadScene("Level2");

        }
        if (sceneName == "Level2")
        {
            SceneManager.LoadScene("FinalBossLevel");
        }

    }

    public int passIndex(int index)
    {
        return index;
    }

    public string passName(string name)
    {
        return name;
    }

    public void updateToken()
    {
        print(dreamToken);
        amount.text = dreamToken.ToString();

    }
    public static int returnHealthAmount()
    {
        return healthPotion;
    }
    public static int returnBlockPotion()
    {
        return healthBlock;
    }
    public static int returnSpeedPotion()
    {
        return speedPotion;
    }
    
}
