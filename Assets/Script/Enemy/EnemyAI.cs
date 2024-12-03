using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    public float walkSpeed;
    public float chaseSpeed;
    private Vector2 Velocity;

    private GameObject patrolTarget;
    private GameObject[] patrolPoints;
    private Vector3 homeBase;
    private bool reachTarget;

    private List<Vector3> pathFinding;
    private int pathIndex;

    private GameObject player;
    private bool isPlayerinSight;
    private float playerDistance;

    public Rigidbody2D rb2D;


    public float currentHealth = 100;
    private GameObject dreamToken;
    private GameObject cloneToken;
    private GameObject healthpack;
    private GameObject cloneHealth;

    public float zPosition;
    public float inRange;
    int randomNum;

    public void adjustCurrentHealth(int adj)
    {
        if (currentHealth > 0)
        {
            currentHealth += adj;
        }
    }

    // Use this for initialization
    void Start()
    {
        pathIndex = 0;
        pathFinding = new List<Vector3>();
        isPlayerinSight = false;

        //Get player
        player = GameObject.FindGameObjectWithTag("Player");

        //Get home base position to patrol back
        homeBase = transform.position;

        //Find the closet patrol point and set it as the patrol target
        patrolPoints = GameObject.FindGameObjectsWithTag("patrolPoint");
        float distance;
        float closetDistance = 10f;
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            distance = Vector3.Distance(patrolPoints[i].transform.position, transform.position);
            if (distance < closetDistance)
            {
                closetDistance = distance;
                patrolTarget = patrolPoints[i];
            }

        }

        reachTarget = false;

        rb2D = GetComponent<Rigidbody2D>();

        dreamToken = GameObject.FindGameObjectWithTag("Dream Token");

        healthpack = GameObject.FindGameObjectWithTag("healthpack");
    }

    void patrolWalk()
    {
        //Get distance between enemy and patrol target
        float targetDistance = Vector3.Distance(patrolTarget.transform.position, transform.position);
        float baseDistance = Vector3.Distance(homeBase, transform.position);

        if (reachTarget == false)
        {
            if (targetDistance > 0.1f
                )
            {
                //Patrol to the target
                movingAI(patrolTarget.transform.position, walkSpeed);

            }
            else
            {
                reachTarget = true;
            }
        }
        //If reached target, patrol back to home base
        else if (reachTarget == true)
        {
            if (baseDistance > 0.1f)
            {
                //Patrol to the base
                movingAI(homeBase, walkSpeed);
            }
            else
            {
                reachTarget = false;
            }
        }

    }

    void movingAI(Vector3 target, float speed)
    {
        //Enemy is at SW of target
        if (target.y > transform.position.y && target.x > transform.position.x)
        {
            Velocity.x = speed;
            Velocity.y = speed;
            rb2D.MovePosition(rb2D.position + Velocity * Time.deltaTime);
        }

        //Enemy is at SE of target
        else if (target.y > transform.position.y && target.x < transform.position.x)
        {
            Velocity.x = -speed;
            Velocity.y = speed;
            rb2D.MovePosition(rb2D.position + Velocity * Time.deltaTime);
        }

        //Enemy is at S of target
        else if (target.y > transform.position.y && target.x == transform.position.x)
        {
            Velocity.x = 0;
            Velocity.y = speed;
            rb2D.MovePosition(rb2D.position + Velocity * Time.deltaTime);
        }

        //Enemy is at NE of target
        else if (target.y < transform.position.y && target.x < transform.position.x)
        {
            Velocity.x = -speed;
            Velocity.y = -speed;
            rb2D.MovePosition(rb2D.position + Velocity * Time.deltaTime);
        }

        //Enemy is at NW of target
        else if (target.y < transform.position.y && target.x > transform.position.x)
        {
            Velocity.x = speed;
            Velocity.y = -speed;
            rb2D.MovePosition(rb2D.position + Velocity * Time.deltaTime);
        }

        //Enemy is at N of target
        else if (target.y < transform.position.y && target.x == transform.position.x)
        {
            Velocity.x = 0;
            Velocity.y = -speed;
            rb2D.MovePosition(rb2D.position + Velocity * Time.deltaTime);
        }

        //Enemy is at W of target
        else if (target.y == transform.position.y && target.x > transform.position.x)
        {
            Velocity.x = speed;
            Velocity.y = 0;
            rb2D.MovePosition(rb2D.position + Velocity * Time.deltaTime);
        }

        //Enemy is at E of target
        else if (target.y == transform.position.y && target.x < transform.position.x)
        {
            Velocity.x = -speed;
            Velocity.y = 0;
            rb2D.MovePosition(rb2D.position + Velocity * Time.deltaTime);
        }
    }

    void chasingPlayer()
    {
        //Chasing player if player is in range       
        if (playerDistance > 0.4f)
        {
            movingAI(player.transform.position, chaseSpeed);
        }
    }

    void gameOver()
    {
        //Game_Over when health is 0//
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            
            randomNum = Random.Range(0, 2);
            if (randomNum % 2 == 0)
            {
                //Drop dream token
                cloneToken = Instantiate(dreamToken, transform.position, transform.rotation);
                cloneToken.transform.position = new Vector3(player.transform.position.x + 0.15f, player.transform.position.y, player.transform.position.z + zPosition);
                cloneToken.SetActive(true);
            }
            else if (randomNum % 2 == 1)
            {
                // Drop Healthpack
                cloneHealth = Instantiate(healthpack, transform.position, transform.rotation);
                cloneHealth.transform.position = new Vector3(player.transform.position.x + 0.15f, player.transform.position.y, player.transform.position.z + zPosition);
                cloneHealth.SetActive(true);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        gameOver();

        //Get distance between enemy and player
        playerDistance = Vector3.Distance(player.transform.position, transform.position);
        
        if (playerDistance <= inRange)
        {
            chasingPlayer();

            //If enemy detected player, start recording coordinate for going back later
            pathFinding.Add(transform.position);
            //Debug.Log(transform.position);
            isPlayerinSight = true;
            pathIndex++;
        }
        else
        {
            //If player hasn't been detected, keep patrolling
            if (isPlayerinSight != true)
            {
                patrolWalk();
            }
            //Else if player has been detected, use pathFinding to go back to the position where the player is first detected.
            else
            {
                //Move to the last saved coordinate
                movingAI(pathFinding[pathIndex-1], walkSpeed);

                //Remove the coordinate that the enemy has moved to
                pathFinding.RemoveAt(pathIndex-1);
                pathIndex--;

                if (pathIndex == 0)
                {
                    isPlayerinSight = false;
                }
            }
            
        }

    }

}
