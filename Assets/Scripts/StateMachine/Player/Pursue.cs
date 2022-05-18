using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : StateMachine
{
    public Pursue(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon, GameObject target) : base(agent, obstacle, weapon)
    {
        currentState = STATE.PURSUE;
        this.target = target;
    }

    public override void Enter()
    {
        base.Enter();
        agent.enabled = true;
        Chase();
    }

    public override void Update()
    {
        Chase();
        if (Vector3.Distance(agent.transform.position,dest) <= weapon.weapon.range)
        {
            stage = EVENT.EXIT;
            nextState = new Attack(agent,obstacle,weapon,target);   
            agent.ResetPath();
        }
        if (CheckLeftMouseClick())
        {
            stage = EVENT.EXIT;
        }
        
    }

    public override void Exit()
    {
        agent.enabled = false;
    }
}
