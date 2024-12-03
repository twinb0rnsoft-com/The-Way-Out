using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToolBar : MonoBehaviour {

    int healthPotion = 3;
    int healthBlock = 3;
    int speedPotion = 3;

    public Text healthAmount;
    public Text speedAmount;
    public Text blockAmount;



    private Health health;
    private Stamina stamina;
    private PlayerControl player;

    public bool useSpeed = false;
    // speed timer, block timer
    private float[] timer = new float[] { 10.0f, 20.0f };

    //private float timer = 0f;
    // Use this for initialization
    void Start () {

        //   healthPotion = ShopV2.returnHealthAmount();
        //healthBlock = ShopV2.returnBlockPotion();
      //  speedPotion = ShopV2.returnSpeedPotion();
        setDescription();

        health = gameObject.GetComponent<Health>();
        stamina = gameObject.GetComponent<Stamina>();
        player = gameObject.GetComponent<PlayerControl>();


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
       
        //use health potion
       if (Input.GetKeyDown(KeyCode.Alpha1))
            {
               if (healthPotion != 0)
                 {
                     healthPotion -= 1;

                     health.currHealth += 30f;
                 }
           
        }
       //use speed potion
        if(Input.GetKeyDown(KeyCode.Alpha2))
            {
            if (speedPotion != 0)
            {
                if (player.isRunning == true)
                {
                    speedPotion -= 1;
                    if(timer[0] > 0)
                    {
                        useSpeed = true;
                        stamina.currentStamina -= 0 ;
                        timer[0] -= Time.deltaTime;
                    }
                  

                }

            }

        }
        //use block potion

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (healthBlock != 0)
            {
                healthBlock--;
                if (timer[1] > 0)
                {
                    Debug.Log(Time.deltaTime);

                    health.decreaseHealth = 0.0f;
                    timer[1] -= Time.deltaTime;
                    Debug.Log("Working");



                }
                else
                {
                    health.decreaseHealth = 0.02f;
                }

            }

        }



    }
}
