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
    public Text healthRatio;

    public float decreaseHealth;
	#endregion

	// Use this for initialization
	void Start () {
		currHealth = maxHealth;
		displayHealth();

        decreaseHealth = 0.02f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        currHealth -= decreaseHealth;
        displayHealth();
	}



	public void displayHealth()
    {
		float ratio = 0f;
         ratio = currHealth / maxHealth;

        healthbar.value = ratio;
        healthRatio.text = (ratio*100).ToString() + "%";
       
		if(currHealth <= 0)
        {
            currHealth = 0;
            healthRatio.text = "0%";
            SceneManager.LoadScene("DeathScene");

        }
        if (currHealth > 100)
        {
            healthRatio.text = "100%";
        }
    }
}
