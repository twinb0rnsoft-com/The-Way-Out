using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalWeapon : MonoBehaviour {

    public Image weaponUI;
    public Text weaponDurability, weaponDamage;
    public float attackRange;

    private GameObject target;
    private GameObject finalWeapon;
    public int weaponDamge;
    private bool isWeaponPickup;
    public bool isWeaponEquipped;

    private GameObject healthpack;
    private GameObject cloneHealth;
    int randomNum;   

	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("FinalBoss");
        finalWeapon = GameObject.FindGameObjectWithTag("Weapon Pickup");
        healthpack = GameObject.FindGameObjectWithTag("healthpack");

        isWeaponPickup = true;
        isWeaponEquipped = false;
	}
	
	// Update is called once per frame
	void Update () {

        pickupWeapon();

        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack(weaponDamge);
        }

    }

    // Function to pickup weapon
    void pickupWeapon()
    {
        
        //Get distance between player and pickup weapon
        float distance = Vector3.Distance(finalWeapon.transform.position, transform.position);

        //If distance is in range, pick up the weapon
        if (distance < 0.055f)
        {
            if (isWeaponPickup == true)
            {
                // Display picked up weapon
                weaponUI.sprite = finalWeapon.GetComponent<SpriteRenderer>().sprite;
            }

            // Display weapon's durability
            if (finalWeapon.GetComponent<SpriteRenderer>().sprite.name == "Holy Sword")
            {
                // Deactivate weapon on the map
                finalWeapon.SetActive(false);
                isWeaponPickup = false;
                isWeaponEquipped = true;

                weaponDurability.text = "Durability: ∞";
                weaponDamage.text = "Damage: 10";
            }
          
        }
        
    }

    private void Attack(int point)
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Debug.Log(distance);

        //Check if weapon is available
        if (isWeaponEquipped == true)
        {
            //Check if enemy is already killed or not
            if (target.activeSelf == true)
            {
                //Check for distance between enemy and player
                if (distance < attackRange)
                {

                    //Attack final boss
                    FinalBoss boss = (FinalBoss)target.GetComponent("FinalBoss");
                    boss.playerAttack(point);

                    //Drop health potion randomly
                    randomNum = Random.Range(0, 10);
                    if (randomNum % 2 == 0)
                    {
                        //Drop dream token
                        cloneHealth = Instantiate(healthpack, transform.position, transform.rotation);
                        cloneHealth.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.1f, transform.position.z);
                        cloneHealth.SetActive(true);
                    }
                    

                }
            }
        }

    }
}
