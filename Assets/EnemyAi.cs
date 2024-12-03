using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public float waltMoveFoce = 0f;
    public float runMoveForce = 0f;
    public float MoveForce = 0f;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsObstacles;
    private Rigidbody rbody;
    public float wallCheckDistance = 0f;
    private Vector3 moveDirection;
    private bool targetFound;


    public float shootRate = 0f;
    private float shootTimeStamp = 0f;
    public GameObject playerObject;
    public float distanceFromTarget = 0f;
    public float saftDistance = 0f;
    private bool shotFired = false;

    public float runTurnRate = 0f;
    public float runTurnTimeStamp = 0f;
    public float runTurnDistanceCheck = 0f;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        moveDirection = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDirection);
        MoveForce = waltMoveFoce;
        runTurnRate = Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetFound)
        {
            Shoot();
        }
        else
        {
            LookForTarget();
        }

        distanceFromTarget = Vector3.Distance(transform.position, playerObject.transform.position);
    }

    void Shoot()
    {
        if (!shotFired)
        {
            playerObject.GetComponent<PlayerControl>().GetComponent<Health>().currHealth -= 1;
            MoveForce = runMoveForce;
            shotFired = true;
            moveDirection = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDirection);
            shootTimeStamp = Time.time + shootRate;
        }
        else
        {
            Hide();
        }

    }

    void Hide()
    {
        if (distanceFromTarget < saftDistance)
        {
            RunToHide();
        }
        else
        {
            MoveForce = waltMoveFoce;
            shotFired = false;
            targetFound = false;
            moveDirection = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    void RunToHide()
    {
        rbody.velocity = moveDirection * MoveForce;

        if (Time.time > runTurnTimeStamp)
        {
            if (Physics.Raycast(transform.position, transform.right, runTurnDistanceCheck, whatIsObstacles))
            {
                moveDirection = -transform.right;
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }
            else if (Physics.Raycast(transform.position, -transform.right, runTurnDistanceCheck, whatIsObstacles))
            {

                moveDirection = transform.right;
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }
            else
            {
                moveDirection = ChooseDirectionLR();
                transform.rotation = Quaternion.LookRotation(moveDirection);

            }
            runTurnRate = Random.Range(0.5f, 1.5f);
            runTurnTimeStamp = Time.time + runTurnRate;
        }

    }

    Vector3 ChooseDirectionLR()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 1);
        Vector3 temp = new Vector3();

        if (i == 0)
        {
            temp = transform.right;

        }
        else if (i == 1)
        {
            temp = -transform.right;

        }

        return temp;

    }

    Vector3 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 3);
        Vector3 temp = new Vector3();

        if (i == 0)
        {
            temp = transform.forward;

        }
        else if (i == 1)
        {
            temp = -transform.forward;

        }
        else if (i == 2)
        {
            temp = transform.right;
        }
        else if (i == 3)
        {
            temp = -transform.right;
        }

        return temp;

    }

    void LookForTarget()
    {
        MoveEnemy();
        targetFound = Physics.Raycast(transform.position, transform.forward, Mathf.Infinity, whatIsPlayer);

    }

    void MoveEnemy()
    {
        rbody.velocity = moveDirection * MoveForce;

        if (Physics.Raycast(transform.position, transform.forward, wallCheckDistance, whatIsObstacles))
        {
            moveDirection = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

    }

}