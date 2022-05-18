using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : StateMachine
{
    public Idle(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon):base(agent, obstacle, weapon)
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
        if (CheckLeftMouseClick())
        {
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        obstacle.enabled = false;        
    }
}
