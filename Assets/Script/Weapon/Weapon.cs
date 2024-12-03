using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {
	
	// Initialize
	#region
    private GameObject[] target;
    public Image weaponUI;
    public int weaponPosition;
    public Text weaponDurability, weaponDamage;
    private bool meleeWeapon = false, 
				availableWeapon = false;
    public float attackRange;

    //Weapon order: Rock, Axe, Sword, Steampunk Axe, Holy Sword, Crossbow, Steampunk Raygun, Gun of Light
    private int[] weaponDmg = new int[] { 10, 15, 25, 30, 40, 20, 25, 37 },
				  currentWeaponDurability = new int[] { 0, 10, 15, 20, 25, 30, 35, 40 };
	private static int[] basedWeaponDurability = new int[] { 0, 10, 15, 20, 25, 30, 35, 40 };
    private bool[] weaponAvailable = new bool[] { true, false, false, false, false, false, false, false };
    #endregion



    // Weapon order: Axe, Holy Sword
    public Sprite[] weaponSprite;
    private static int[] baseDurability = new int[] { 10, 30 };
    private int[] weaponCurrentDmg = new int[] { 5, 10 };
    private int[] weaponCurrentDur = new int[] { 10, 30 };
    private bool[] pickupSignal = new bool[] { true, true };
	[HideInInspector]
	public bool[] weaponInventory = new bool[] { false, false };

	[HideInInspector]
    public GameObject[] weaponPickup;

	// Use this for initialization
	void Start () {
		weaponPosition = 0;

        //Get all the enemies on the map
        target = GameObject.FindGameObjectsWithTag("monsters");

        //Get the GameObject of weapon drop off on the map, and set them inactive
        weaponPickup = GameObject.FindGameObjectsWithTag("Weapon Pickup");
        for (int i = 0; i < weaponPickup.Length; i++)
        {
            weaponPickup[i].SetActive(false);
        }

	}

    // Function to display weapon for pick up when the player is nearby
    void showWeapon()
    {
        for (int i = 0; i < weaponPickup.Length; i++)
        {
            //Get distance between player and pickup weapon
            float distance = Vector3.Distance(weaponPickup[i].transform.position, transform.position);

            //If distance is in range, show the weapon
            if (distance < 0.25f)
            {
                //Check if weapon already picked up
                if(weaponPickup[i].GetComponent<SpriteRenderer>().sprite.name == "Holy Sword" && pickupSignal[1] == true || weaponPickup[i].GetComponent<SpriteRenderer>().sprite.name == "Axe" && pickupSignal[0] == true)
                {
                    weaponPickup[i].SetActive(true);
                }
            }
        }
    }

    // Function to pickup weapon
    void pickupWeapon()
    {
        for (int i = 0; i < weaponPickup.Length; i++)
        {
            //Get distance between player and pickup weapon
            float distance = Vector3.Distance(weaponPickup[i].transform.position, transform.position);

            //If distance is in range, pick up the weapon
            if (distance < 0.15f)
            {
				if (pickupSignal [i] == true) {
					// Display picked up weapon
					weaponUI.sprite = weaponPickup[i].GetComponent<SpriteRenderer> ().sprite;
				} 
               
                // Display weapon's durability
                if (weaponPickup[i].GetComponent<SpriteRenderer>().sprite.name == "Holy Sword")
                {
                    // Deactivate weapon on the map
                    weaponPickup[i].SetActive(false);
                    pickupSignal[1] = false;
                    weaponInventory[1] = true;
                    weaponPosition = 1;

                    weaponDurability.text = "Durability: " + baseDurability[1].ToString();
                    weaponDamage.text = "Damage: " + weaponCurrentDmg[1].ToString();
                }
                else if (weaponPickup[i].GetComponent<SpriteRenderer>().sprite.name == "Axe")
                {
					
                    // Deactivate weapon on the map
                    weaponPickup[i].SetActive(false);
                    pickupSignal[0] = false;
                    weaponInventory[0] = true;
                    weaponPosition = 0;

                    weaponDurability.text = "Durability: " + baseDurability[0].ToString();
                    weaponDamage.text = "Damage: " + weaponCurrentDmg[0].ToString();
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () 
	{
        //Show weapon on the map
        showWeapon();

        pickupWeapon();

		if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weaponPosition == 0 && weaponInventory[1] == true)
            {
                weaponPosition = 1;
            }
            else if (weaponPosition == 1 && weaponInventory[0] == true)
            {
                weaponPosition = 0;
            }
            displayWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (weaponInventory[weaponPosition] == true)
            {
                Attack(-(weaponCurrentDmg[weaponPosition]));
            }
        }
	}

	private void Attack(int point)
    {

        for (int i = 0; i < target.Length; i++)
        {  
            float distance = Vector3.Distance(target[i].transform.position, transform.position);
            Debug.Log(distance);
            //Check if weapon is available
            if (weaponInventory[weaponPosition]  == true)
            {
                //Check if enemy is already killed or not
                if(target[i].activeSelf == true)
                {
                    //Check for distance between enemy and player
                    if (distance < attackRange)
                    {
                        //Check weapon's durability before attack
                        if (weaponCurrentDur[weaponPosition] > 0)
                        {
                            //Attack enemy
                            EnemyAI enemy = (EnemyAI)target[i].GetComponent("EnemyAI");
                            enemy.adjustCurrentHealth(point);

                            //Decrease weapon's durability after a successful hit
                            weaponCurrentDur[weaponPosition] -= 1;
                            
                            //Update new weapon's durability
                            displayWeapon();
                        }
                    }
                }
                
            }
            
        }
    }

	void displayWeapon()
    {
       // Check if weapon is available in inventory
		if (weaponInventory[weaponPosition] == true) {

            // Display weapon
			weaponUI.sprite = weaponSprite[weaponPosition];

			// Check weapon's durability
			if (weaponCurrentDur[weaponPosition] > 0) {
                
				weaponDurability.text = "Durability: " + weaponCurrentDur[weaponPosition].ToString ();
			} else {
				weaponDurability.text = "Durability: BROKEN";
			}

			// Display weapon's damage
			weaponDamage.text = "Damage: " + weaponCurrentDmg[weaponPosition].ToString ();
		} 
    }

}

