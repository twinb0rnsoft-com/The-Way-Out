using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour {

	// Health Variables Declaration
	#region
    public float currHealth;
    public float maxHealth = 100f;
    public Slider healthbar;

    public float decreaseHealth;
	#endregion


	// Use this for initialization
	void Start () {
		currHealth = maxHealth;
		displayHealth();

        decreaseHealth = 0.011f;

        Scene scene = SceneManager.GetActiveScene();

        
        if(scene.name == "FinalBossLevel")
        {
            decreaseHealth = 0f;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        //currHealth -= decreaseHealth;
        displayHealth();
	}



	public void displayHealth()
    {
		float ratio = 0f;
         ratio = currHealth / maxHealth;

        healthbar.value = ratio;
       
       
		if(currHealth <= 0)
        {
            currHealth = 0;
          	
			// Trigger Death animation
//			gameObject.GetComponent<MovementAnimControll>().animFront.SetBool("isDeath",true);
            //get current scene name
            PlayerPrefs.SetString("lastDeathScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("DeathScene");

        }
        if (currHealth > 100)
        {
            currHealth = 100;
        }
    }
}
