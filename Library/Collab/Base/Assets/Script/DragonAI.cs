using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAI : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    public Transform target;
    public float chaseRange;

    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;


    public GameObject projectile;
    public float webForce;

    public int currentHealth = 100;

    public void adjustCurrentHealth(int adj)
    {
        if (currentHealth > 0)
        {
            currentHealth += adj;
        }
    }

    // Use this for initialization
    void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}
	
	// Update is called once per frame
	void Update () {

        adjustCurrentHealth(0);


        //Game_Over when health is 0//
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }


        {




        //////////////////////
        ////Patrol Points/////
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        //Check to see if we have reached the point of the patrol

        if(Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
            //we have reach the patrol point - get to the next one
            //Check to see if wh have anymore patrol points - if not go back to the beginning
            if(currentPatrolIndex + 1 < patrolPoints.Length)
            
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }

        //Turn to face the current patrol point
        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;
        //Made the rotation that we need to face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //Appply the rotation to out transform
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);

        }
        
        


        //////////////////////
        //Chasing Player AI//
        //Get the distance to the target and check to see if it is close to chase
        float distanceToTarget = Vector3.Distance(transform.position,target.position);
        if(distanceToTarget < chaseRange)
        {
            //Start chasing the target - turn and move towards the target
            Vector3 targetDi = target.position - transform.position;
            if(distanceToTarget < chaseRange)
            {
                //Start chasing the target - turn and move twoards the target
                Vector3 targetDir = target.position - transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

                transform.Translate(Vector3.up * Time.deltaTime * speed);



            }
            else
            {
                Vector3 targetDir = target.position - transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            }
        }
        //End Line


        ////////////////////////////////////////////////
        //Check the distance between dragon and player to see if the player is close enough to attack//
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if(distanceToPlayer < attackRange )
        {
            //Check to see if enough time has passed since we last attacked
            if(Time.time > lastAttackTime + attackDelay)
            target.SendMessage("Take Damage", damage);

            //Record the time we attacked
            lastAttackTime = Time.time;
        }


        //Ranged Attack///
        //Check to see if the player is within our attack range
        float distanceToPlayerAttack = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayerAttack < attackRange)
        {
            //Turn towards the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

            //Check to see if it's time to attack
            if(Time.time > lastAttackTime + attackDelay)
            {
                //Raycast to see if we have line of sight to the target
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);
                //Check to see if we hit anything and what it was
                if(hit.transform == target)
                {
                    //Hit the player - fire the projectitle
                    GameObject newWeb = Instantiate(projectile, transform.position, transform.rotation);

                    newWeb.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, webForce));
                    lastAttackTime = Time.time;
                }
            }

        }



	}
}
