using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public float speed;
    public PlayerControl player;
  
    public float rotationSpeed;
    public int damage;
    private Rigidbody2D rigidBody;
    public Vector2 offset = new Vector2(0.4f, .1f);
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerControl>();

        rigidBody = GetComponent<Rigidbody2D>();

        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }


    }

    // Update is called once per frame
    //* player.transform.position.x , * transform.localScale.y  (rigidBody.velocity.y

    void Update () {
		Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f),  Random.Range(-10.0f, 10.0f),0);
		rigidBody.velocity = new Vector2 (speed * -player.transform.position.x, speed* Random.Range(-2f,2f));//* player.transform.position.y);
        rigidBody.angularVelocity = rotationSpeed;
		rigidBody.AddRelativeForce(Vector3.forward * Time.deltaTime * speed); 
		//temp.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        rigidBody.AddForce(transform.forward * 1000);
    }
      void OnTriggerEnter2D(Collider2D other)
       {
        if (other.gameObject.CompareTag("Player"))
       
         {

           other.GetComponent<Health>().currHealth -= damage;
		//	Destroy(other.GetComponent<FireballRaycast>().fireball);

        }
    }
}
