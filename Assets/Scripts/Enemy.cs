using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lots of Inheritance
public class Enemy : CombatAgent
{
    public GameObject player;
    
    [SerializeField]
    bool canHear = true;
    float visionHeight = 3f;
    [SerializeField]
    float visionDistance = 30f;

    private void Alert()
    {
        if (canHear && myState.currentState < StateMachine.STATE.ATTACK) 
        {
            myState.stage = StateMachine.EVENT.EXIT;
            myState.nextState = new EPursue(agent, obstacle, weapon, player);
        }
    }

    private void Update()
    {
        
        if (myState.currentState < StateMachine.STATE.ATTACK && IsLineOfSite(visionDistance) && CanSeePlayer())
        {
            myState.nextState = new EPursue(agent,obstacle,weapon,player);
            myState.stage = StateMachine.EVENT.EXIT;
        }
    }

    protected override void DestroyTarget()
    {
        base.DestroyTarget();
        myState.nextState = new Idle(agent, obstacle, weapon);
        myState.stage = StateMachine.EVENT.EXIT;
    }

    private bool CanSeePlayer()
    {
        if (Mathf.Abs(transform.position.y - player.transform.position.y) > visionHeight) { return false; }
        Vector3 directionOfPlayer = transform.position - player.transform.position;
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
        Vector3 directionOfPlayer = player.transform.position - transform.position;

        if (Physics.Raycast(transform.position, directionOfPlayer, out hit, distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
