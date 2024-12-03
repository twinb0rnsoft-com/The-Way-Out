using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ShopPopUpWeapon : MonoBehaviour {

    public Sprite[] consumableSprite;
    public Image weaponsUI;
    public int consumableIndex = 3;
    //public int index

    //  public static ShopManager shop1 = new ShopManager();
    public static ShopV2 shop1 = new ShopV2();
    public Text info;

    public int index;
    public string consumName;

    // Use this for initialization
    void Start () {
      
      
	}
	
	// Update is called once per frame
	void Update () {
      
		index = ShopV2.index;
        consumName = ShopV2.consumableName;
        displayWeaponMessage(index, consumName);

    }
   public void displayWeaponMessage(int index, string consumableName)
    {
        weaponsUI.sprite = consumableSprite[index];
        info.text = consumableName + " purchased";
        //Text.GetTextAnchorPivot 
    }
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
