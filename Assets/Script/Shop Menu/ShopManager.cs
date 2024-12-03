using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShopManager : MonoBehaviour {
    public static ShopManager shopManager;
    public static PlayerControl p1 = new PlayerControl();
    //ingame money
    private static int dreamToken;
    // private static int dreamToken = 100;

    //Weapon order: Rock, Axe, Sword, Steampunk Axe, Holy Sword, Crossbow, Steampunk Raygun, Gun of Light
    //costs for weapons
    private int axeCost = 5;
    private int VicSwordCost = 9;
    private int hammerCost = 15;
    private int hSwordCost = 23;
    private int rockCost = 0;
    private int crossbowCost = 11;
    private int raygunCost = 17;
    private int lightgunCost = 25;

    private int[] weaponCost = new int[] { 0, 5, 9, 15, 23, 11, 17, 25 };

    // pass info if the weapons are availble after purchase
    //Weapon order: Rock, Axe, Sword, Steampunk Axe, Holy Sword, Crossbow, Steampunk Raygun, Gun of Light
    public static bool[] weaponEnabled = new bool[] { true, true, true, true, true, true, true, true }; 

    //pass info
    public static int index;
    public static string weapName;

    public static ShopPopUpWeapon pop1 = new ShopPopUpWeapon();
    //UI pictures and text

    public Text amount;

    
    // Use this for initialization
    void Start() {
        shopManager = this;

        dreamToken = DreamTokenCollecting.returnTokenCount();

        amount.text = dreamToken.ToString();
    }

    // Update is called once per frame
    void Update() {
       // UpdateUI();
    }

    public void buyAxe()
    {
        if (dreamToken < axeCost)
        {
			Debug.Log("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");
        }
        else
        {
            dreamToken -= axeCost;
            index = 0;
            weapName = "Stone Axe";
            Debug.Log("Stone Axe Purchased");
			changeScene ("ShopPopUp");
            //passName("Stone Axe");
        //    pop1.displayWeaponMessage(0, "Stone Axe");
            print("Stone Axe purchased");

            weaponEnabled[1] = true;
        }
    }

    public void buyVicSword()
    {
        if (dreamToken < VicSwordCost)
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= VicSwordCost;
            index = 1;
            weapName = "Victorian Axe";
			changeScene ("ShopPopUp");
            print("Victorian Sword purchased");

            weaponEnabled[2] = true;
        }
    }

    public void buyHammer()
    {
        if (dreamToken < hammerCost)
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= hammerCost;
            index = 2;
            weapName = "Steampunk Hammer";
			changeScene ("ShopPopUp");
            print("Steampunk Hammer purchased");

            weaponEnabled[3] = true;
        }
    }

    public void buyHSword()
    {
        if (dreamToken < hSwordCost)
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= hSwordCost;
            index = 3;
            weapName = "Holy Sword";
			changeScene ("ShopPopUp");
            print("Holy Sword purchased");

            weaponEnabled[4] = true;
        }
    }

    public void buyRock()
    {
        if (dreamToken < rockCost)
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= rockCost;
            index = 4;
            weapName = "Rock";
			changeScene ("ShopPopUp");
            print("Rock purchased");

            weaponEnabled[0] = true;
        }
    }

    public void buyCrossbow()
    {
        if (dreamToken < crossbowCost)
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= crossbowCost;
            index = 5;
            weapName = "Crossbow";
			changeScene ("ShopPopUp");
            print("Crossbow purchased");

            weaponEnabled[5] = true;
        }
    }

    public void buyRayGun()
    {
        if (dreamToken < raygunCost)
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= raygunCost;
            index = 6;
            weapName = "Steampunk Ray-Gun";
			changeScene ("ShopPopUp");
            print("Steampunk Ray-Gun purchased");

            weaponEnabled[6] = true;
        }
    }

    public void buyLightGun()
    {
        if (dreamToken < lightgunCost)
        {
            print("Not Enough Dream Token!");
            changeScene("ShopErrorWindow");

        }
        else
        {
            dreamToken -= lightgunCost;
            index = 7;
            weapName = "Holy Lightgun";
			changeScene ("ShopPopUp");
            print("Holy Lightgun purchased");

            weaponEnabled[7] = true;
        }
    }

    //change scene
    public void changeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
         //Application.LoadLevel(sceneName);
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
        
    }

}
