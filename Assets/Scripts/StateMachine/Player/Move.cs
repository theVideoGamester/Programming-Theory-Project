using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : StateMachine
{
    public Move(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon,Vector3 dest) : base(agent, obstacle, weapon)
    {
        currentState = STATE.MOVING;
        this.dest = dest;
    }

    public override void Enter()
    {
        base.Enter();
        agent.enabled = true;
        agent.SetDestination(dest);
    }

    public override void Update()
    {
        if (CheckLeftMouseClick()) { 
            agent.SetDestination(dest);
            if (target != null)
            {
                stage = EVENT.EXIT;
            }
        }
        if (!agent.hasPath)
        {
            stage = EVENT.EXIT;
            nextState = new Idle(agent,obstacle,weapon);
        }
    }

    public override void Exit()
    {
        agent.enabled = false;
    }
}
