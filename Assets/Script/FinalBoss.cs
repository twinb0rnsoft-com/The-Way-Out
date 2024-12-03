using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour {
	public GameObject boss;
	public float bossMaxHealth = 50f;
	public float bossCurrHealth ;

	public Slider healthbar;

	// Use this for initialization
	void Start () {
		bossCurrHealth = bossMaxHealth;
		displayHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		displayHealth ();
	}

	public void playerAttack(int damage)
	{
		bossCurrHealth -= damage;
        displayHealth();
	}

	void displayHealth()
	{   
		//playerAttack (5);
		float ratio = 0f;
		 
		ratio = bossCurrHealth / bossMaxHealth;
		//Debug.Log (ratio);
		healthbar.value = ratio;

		if (bossCurrHealth == 0f) {
			boss.SetActive (false);
            SceneManager.LoadScene("Ending");

		}
	}
}
