using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballRaycast : MonoBehaviour {
    //


    //shoot player at range
        public float timer;
        public float playerRange;
	    public GameObject fireball;
		public GameObject fireballCollider;
        public PlayerControl player;
        public Transform launchPoint;

    public GameObject temp;

    bool isFiring = true;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerControl>();

    }
	
	// Update is called once per frame
	void Update () {
        //transform.localScale.x > 0 &&
        //player.transform.position.x < transform.position.x &&
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange , transform.position.y, transform.position.z));
        //if player is on the right of boss

        if (  player.transform.position.x > transform.position.x - playerRange  && isFiring)
		{
			
			launchPoint.position += RandomInCone (.5f);
			temp =  (GameObject) Instantiate(fireball, launchPoint.position, launchPoint.rotation);
            StartCoroutine(CanShoot());
            Destroy(temp, 5);

        }
        //if player is on the left of boss
        //player.transform.position.x > transform.position.x && +1f*transform.forward
        if (  player.transform.position.x < transform.position.x + playerRange && isFiring)
        {
			launchPoint.position += RandomInCone (.5f);
			temp =  (GameObject) Instantiate(fireball, launchPoint.position , launchPoint.rotation);
            StartCoroutine(CanShoot());
			//OnCollisionEnter (temp);
            Destroy(temp, 5);

        }

    }
	public static Vector3 RandomInCone(float radius)
	{
		//(sqrt(1 - z^2) * cosϕ, sqrt(1 - z^2) * sinϕ, z)
		float radradius = radius * Mathf.PI / 360;
		float z = Random.Range(Mathf.Cos(radradius), 1);
		float t = Random.Range(0, Mathf.PI * 2);
		return new Vector3(Mathf.Sqrt(1 - z * z) * Mathf.Cos(t), Mathf.Sqrt(1 - z * z) * Mathf.Sin(t), z);
	}
	//void OnCollisionEnter(Collision2D other)
	//{
	//	if (other.gameObject.name == "fireballCollider")
	////	{
	//		Destroy(other.gameObject, 0);
	//	}

	//}
        IEnumerator CanShoot()
        {
            isFiring = false;
            yield return new WaitForSeconds(timer);
            isFiring = true;


        }
        
}
