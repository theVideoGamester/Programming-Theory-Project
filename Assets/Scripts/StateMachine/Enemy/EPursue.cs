using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EPursue : StateMachine
{
    public EPursue(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon, GameObject target) : base(agent, obstacle, weapon)
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
        if (!agent.hasPath)
        {
            stage = EVENT.EXIT;
            nextState = new EAttack(agent, obstacle, weapon, target);
            agent.ResetPath();
        }
    }

    public override void Exit()
    {
        agent.enabled = false;
    }
}
