using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lots of Inheritance
public class Enemy : NavAgent
{
    [SerializeField] private float visionDistance = 35f;
    [SerializeField] private float hearingDistance = 60f;
    [SerializeField] private float visionHeight = 3f;
    private Player player;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 5;

        //Abstraction
        setAgent();
        startMovement(transform.position);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerTransform = player.transform;
        myWeapon = gameObject.GetComponent<Weapon>();
        //Debug.Log(myWeapon.weaponName);
    }

    // Update is called once per frame
    void Update()
    {
        //Abstraction
        endMovement();
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        switch (myState)
        {
            case states.idle:
            case states.beginMove:
            case states.move:
                //Abstraction
                if (Detection())
                {
                    //Debug.DrawLine(transform.position, player.transform.position, Color.red);
                    player.inCombat = true;
                    target = playerTransform.gameObject;
                    myState = states.moveToRange;
                }
                break;
            case states.moveToRange:
                if (!player.noisy)
                {
                    player.noisy = true;
                }
                if (target == null)
                {
                    myState = states.idle;
                }
                else if (Vector3.Distance(transform.position, target.transform.position) < myWeapon.range)
                {
                    myState = states.attack;
                    if (agent.enabled) {
                        agent.ResetPath();
                    }
                }
                else
                {
                    //Abstraction
                    startMovement(playerTransform.position);
                }
                break;
            case states.attack:
                //Abstraction
                endMovement();

                transform.LookAt(target.transform);
                targetAgent = target.GetComponent<NavAgent>();
                InvokeRepeating("Attack", .2f, attackSpeed);
                myState = states.combat;       
                break;
            case states.combat:
                if (target != null && !CheckTargetDistance())
                {
                    myState = states.moveToRange;
                    CancelInvoke();
                }
                break;
        }
    }
    
    
    #region detection
    private bool Detection()
    {
        float distance = visionDistance;

        if (player.noisy)   
        {
            distance = hearingDistance;
        }

        if (Vector3.Distance(transform.position,playerTransform.position) <= distance) 
        {
            //Abstraction
            if (CanSeePlayer() && IsLineOfSite(distance))
            {
                return true;
            }
        }
        return false;
    }
    private bool CanSeePlayer()
    {
        if (Mathf.Abs(transform.position.y - playerTransform.position.y) > visionHeight)
        {
            return false;
        }
        Vector3 directionOfPlayer = transform.position - playerTransform.position;
        float angle = Vector3.Angle(transform.forward, directionOfPlayer);
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            return true;
        }

        return false;
    }

    private bool IsLineOfSite(float distance)
    {
        RaycastHit hit;
        Vector3 directionOfPlayer = playerTransform.position - transform.position;

        if (Physics.Raycast(transform.position, directionOfPlayer, out hit, distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
    #endregion
}
