using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lots of Inheritance
public class Enemy : NavAgent
{
    /*
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
    */
}
