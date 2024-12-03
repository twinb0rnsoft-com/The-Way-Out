using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToolBar : MonoBehaviour {

    int healthPotion;
    int healthBlock;
    int speedPotion;

    public Text healthAmount;
    public Text blockAmount;
    public Text speedAmount;

    // Use this for initialization
    void Start () {

        healthPotion = ShopV2.returnHealthAmount();
        healthBlock = ShopV2.returnBlockPotion();
        speedPotion = ShopV2.returnSpeedPotion();
        setDescription();
    }
	
	// Update is called once per frame
	void Update () {
        usePotions();
        setDescription();


    }
    public void setDescription()
    {
        healthAmount.text = healthPotion.ToString();
        blockAmount.text = healthBlock.ToString();
        speedAmount.text = speedPotion.ToString();
    }
    public void usePotions()
    {
        if( Input.GetKey(KeyCode.Alpha1))//(Input.GetKeyDown("Alpha1"))
        {
            healthPotion -= 1;

            GetComponent<Health>().currHealth += 30f;
        }

        if (Input.GetKey(KeyCode.Alpha2))//(Input.GetKeyDown("Alpha1"))
        {
            speedPotion -= 1;

            GetComponent<Stamina>().currentStamina += 30f;
        }

        if (Input.GetKey(KeyCode.Alpha3))//(Input.GetKeyDown("Alpha1"))
        {
            healthPotion -= 1;

            GetComponent<Health>().currHealth += 30f;
        }
    }
}
