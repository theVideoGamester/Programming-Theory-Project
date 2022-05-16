using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : StateMachine
{
    public Attack(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon, GameObject target) : base(agent, obstacle, weapon)
    {
        currentState = STATE.ATTACK;
        
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
