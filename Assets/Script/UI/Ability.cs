using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {


    // Initialize
    private GameObject[] ability;
    private PlayerControl player;
    private Health health;

    // Order: Health Block, God Speed, Invisible Armor
    private bool[] pickupSignal = new bool[] { true, true, true };
    private bool[] startSignal = new bool[] { false, false, false };
    private float[] timer = new float[] { 20.0f, 10.0f, 10.0f };

	// Use this for initialization
	void Start () {

        // Get all the abilities on the map, and set them inactive
        ability = GameObject.FindGameObjectsWithTag("Ability");
        for (int i = 0; i < ability.Length; i++)
        {
            ability[i].SetActive(false);
        }

        player = gameObject.GetComponent<PlayerControl>();
        health = gameObject.GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {

        // Show ability for pickup
        showAbility();

        // Pick up ability
        pickupAbility();


        // Health Block
        /*
        if (startSignal[0] == true)
        {   
            if (timer[0] > 0)
            {
                timer[0] -= Time.deltaTime;
                health.decreaseHealth = 0.0f;
            }
            else
            {
                health.decreaseHealth = 0.02f;
            }
     
        }

        // God Speed
        if (startSignal[1] == true)
        {
            Debug.Log(timer[1]);
            if (timer[1] > 0)
            {
                timer[1] -= Time.deltaTime;
                player.walkspeed = 0.6f;
            }
            else
            {
                player.walkspeed = 0.3f;
            }

        }
        

        // Invisible Armor
        if (startSignal[2] == true)
        {
            if (timer[2] > 0)
            {
                timer[2] -= Time.deltaTime;
                player.damageTaken = 0f;
            }
            else
            {
                player.damageTaken = 8f;
            }
        }
        */

	}

    // Function to display ability for pick up when the player is nearby
    void showAbility()
    {
        for (int i = 0; i < ability.Length; i++)
        {   
            // Get distance between player and pickup ability
            float distance = Vector3.Distance(ability[i].transform.position, transform.position);

            // If distance is in range, show the ability
            if (distance < 0.35f)
            {
                // Check if ability already picked up
                if (ability[i].GetComponent<SpriteRenderer>().sprite.name == "Health Block" && pickupSignal[0] == true || ability[i].GetComponent<SpriteRenderer>().sprite.name == "God Speed" && pickupSignal[1] == true || ability[i].GetComponent<SpriteRenderer>().sprite.name == "Invisible Armor" && pickupSignal[2] == true)
                {
                    ability[i].SetActive(true);
                }
            }
        }
    }

    // Function to pick up ability
    void pickupAbility()
    {
        for (int i = 0; i < ability.Length; i++)
        {
            float distance = Vector3.Distance(ability[i].transform.position, transform.position);

            if (distance < 0.15f)
            {
                // Deactive ability after picked up
                ability[i].SetActive(false);

                //Health Block
                if (ability[i].GetComponent<SpriteRenderer>().sprite.name == "Health Block" && pickupSignal[0] == true)
                {
                    pickupSignal[0] = false;
                    startSignal[0] = true;

                    //Add to counter in Toolbar.cs
                    GetComponent<ToolBar>().healthBlock += 1;
                }

                //God Speed
                else if (ability[i].GetComponent<SpriteRenderer>().sprite.name == "God Speed" && pickupSignal[1] == true)
                {
                    pickupSignal[1] = false;
                    startSignal[1] = true;

                    //Add to counter in Toolbar.cs
                    GetComponent<ToolBar>().speedPotion += 1;
                }

                //Invincibility
                else if (ability[i].GetComponent<SpriteRenderer>().sprite.name == "Invisible Armor" && pickupSignal[2] == true)
                {
                    pickupSignal[2] = false;
                    startSignal[2] = true;

                    //Add to counter in Toolbar.cs
                    GetComponent<ToolBar>().invisibleArmor += 1;
                }
            }
        }
    }

}
