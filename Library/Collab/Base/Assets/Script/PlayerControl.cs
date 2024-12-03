using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {
    
	private Transform enemyTrans;
	private GameObject enemyObj;
    private Vector3 moveDirection = Vector3.zero;
	public float speed;

    //Player's Movement Variables
    public float speedTimer;
    public float walkspeed,runSpeed;

    public float damageTaken;

	IEnumerator WaitBeforeDisapear()
	{
		yield return new WaitForSeconds(2.0f);
	}

    private void Start()
    {
		enemyObj = GameObject.FindGameObjectWithTag ("monsters");
       // speedTimer = 3.0f;
		speed = walkspeed;

        damageTaken = 8f;
    }
		
	void Update()
	{
        ManageMovement();

        speed = walkspeed;
    }

	public void ManageMovement()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector3.up * (Time.deltaTime * speed));

		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (Vector3.down * (Time.deltaTime * speed));


		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector3.left * (Time.deltaTime * speed));

		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right * (Time.deltaTime * speed));
		}

        if (Input.GetKey (KeyCode.Z))
        {

            GetComponent<Stamina>().useStamina();
            if (GetComponent<Stamina>().currentStamina <= 0)
            {
                speed = walkspeed;

            }
            else if (GetComponent<Stamina>().currentStamina > 0)
            {
                speed = runSpeed;
            }


        } 
	}	

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("monsters"))
        {
            GetComponent<Health>().currHealth -= damageTaken;
            GetComponent<Health>().displayHealth();
        }
        else if (other.gameObject.CompareTag("door"))
        {
          
            GetComponent<SceneManage>().changeLevel();
        }
		else if (other.gameObject.CompareTag("healthpack"))
		{
			other.gameObject.SetActive (false);
			GetComponent<Health>().currHealth += 5f;
			GetComponent<Health>().displayHealth();
		}
        //test door for next level
     //   else if (other.gameObject.CompareTag("test"))
     //   {
//GetComponent<SceneManage>().changeLevel();
    //    }
    }

    public void TakeDamage(int damage)
    {
       
		if (GetComponent<Health>().currHealth <= 0)
        {
			GetComponent<Health>().displayHealth();
            Debug.Log("Dead");
        }
    }

    

    

   
}
