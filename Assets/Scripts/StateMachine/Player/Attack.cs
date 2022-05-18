using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : StateMachine
{
    CombatAgent combatAgent;
    float rotationSpd = 10f;
    public Attack(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon, GameObject target) : base(agent, obstacle, weapon)
    {
        currentState = STATE.ATTACK;
        combatAgent = agent.gameObject.GetComponent<CombatAgent>();
        combatAgent.targetAgent = target.GetComponent<CombatAgent>();
        this.target = target;
        Vector3 pos = new Vector3(agent.transform.position.x, 10, agent.transform.position.z);
        Vector3 targPos = new Vector3(target.transform.position.x, 10, target.transform.position.z); ;
        Vector3 dir = pos - targPos;
        float offset = weapon.weapon.range + 2f;
        dest = target.transform.position + dir.normalized * offset;
        combatAgent.InvokeRepeating("Attack", combatAgent.attackSpeed, combatAgent.attackSpeed);
    }

    public override void Enter()
    {
        base.Enter();
        obstacle.enabled = true;
        
    }

    public override void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(target.transform.position.x, agent.transform.position.y, target.transform.position.z) - new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z));
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, targetRotation, rotationSpd * Time.deltaTime);

        if (CheckDistanceToTarg())
        {
            nextState = new Pursue(agent, obstacle, weapon, target);
            stage = EVENT.EXIT;
            combatAgent.CancelInvoke();
            return;
        }
        if (CheckLeftMouseClick())
        {
            stage = EVENT.EXIT;
            combatAgent.CancelInvoke();
        }
    }

    public override void Exit()
    {
        obstacle.enabled = false;
    }
}
