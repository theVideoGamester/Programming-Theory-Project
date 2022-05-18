using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Lots of Inheritance
public class Player : CombatAgent
{
    private void Start()
    {
        myState = new Initialize(agent, obstacle, weapon);
    }

    public override void Attack()
    {
        if (targetAgent == null)
        {
            myState.nextState = new Idle(agent, obstacle, weapon);
            myState.stage = StateMachine.EVENT.EXIT;
            return;
        }
        base.Attack();
        Collider[] hitColliders = Physics.OverlapSphere(targetAgent.transform.position, 30f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy"))
            {
                hitCollider.SendMessage("Alert");
            }
        }
    }

    protected override void DestroyTarget()
    {
        base.DestroyTarget();
        myState.nextState = new Idle(agent, obstacle, weapon);
        myState.stage = StateMachine.EVENT.EXIT;
    }
}
