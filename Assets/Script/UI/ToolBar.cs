using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBar : MonoBehaviour {

    public int invisibleArmor = 0;
    public int healthBlock = 0;
    public int speedPotion = 0;

    public Text healthAmount;
    public Text speedAmount;
    public Text armorAmount;



    private Health health;
    private Stamina stamina;
    private PlayerControl player;

   
    // Use this for initialization
    void Start () {

          invisibleArmor = ShopV2.returnHealthAmount();
          healthBlock = ShopV2.returnBlockPotion();
          speedPotion = ShopV2.returnSpeedPotion();


        health = gameObject.GetComponent<Health>();
        stamina = gameObject.GetComponent<Stamina>();
        player = gameObject.GetComponent<PlayerControl>();
  
        setDescription();

    }

    // Update is called once per frame
    void Update()
    {
        setDescription();

        //use invisible armor

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(useBlock());
        }

        //use god speed potion
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(useSpeedPotion());
        }

        //use health block potion
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {   
            StartCoroutine(useinvisibleArmors());
        }
    }
    public void setDescription()
    {
        healthAmount.text = healthBlock.ToString();
        armorAmount.text = invisibleArmor.ToString();
        speedAmount.text = speedPotion.ToString();
    }
    //speed potion
    IEnumerator useSpeedPotion()
    {
        if (speedPotion != 0)
        {
            speedPotion--;
            stamina.decreaseStamina = 0f;
            yield return new WaitForSeconds(10);
            stamina.decreaseStamina = 0.25f;

        }
    }

    // block potion
    IEnumerator useBlock()
    {
        if (healthBlock != 0)
        {
            healthBlock--;
            health.decreaseHealth = 0.0f;
            yield return new WaitForSeconds(20);
            health.decreaseHealth = 0.02f;

        }
            
    }
  
    IEnumerator useinvisibleArmors()
    {
        if(invisibleArmor != 0)
        {
            invisibleArmor -= 1;

            player.damageTaken = 0f;
            yield return new WaitForSeconds(20);
            player.damageTaken = 8f;
        }
    }
        
}
