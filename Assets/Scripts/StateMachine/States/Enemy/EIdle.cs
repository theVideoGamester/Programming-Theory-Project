using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EIdle : StateMachine
{
    public EIdle(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon) : base(agent, obstacle, weapon)
    {
        currentState = STATE.IDLE;
    }

    public override void Enter()
    {
        base.Enter();

        obstacle.enabled = true;
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        obstacle.enabled = false;
    }
}
