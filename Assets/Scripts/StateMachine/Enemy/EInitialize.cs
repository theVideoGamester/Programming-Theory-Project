using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EInitialize : StateMachine
{
    public EInitialize(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon) : base(agent, obstacle, weapon)
    {
        currentState = STATE.INITIALIZE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        stage = EVENT.EXIT;
    }

    public override void Exit()
    {
        agent.enabled = false;
        nextState = new EIdle(agent, obstacle, weapon);
    }
}
