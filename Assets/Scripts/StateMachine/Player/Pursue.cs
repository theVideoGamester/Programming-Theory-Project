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
        dest = target.transform.position;
    }

    public override void Enter()
    {
        base.Enter();
        agent.enabled = true;
        agent.SetDestination(dest);
    }

    public override void Update()
    {
        if (Vector3.Distance(agent.transform.position,target.transform.position) <= weapon.range)
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
