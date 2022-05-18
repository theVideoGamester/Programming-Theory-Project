using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine
{
    public enum STATE
    {
        INITIALIZE,IDLE, PATROL, MOVING, ATTACK, PURSUE
    }

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    public STATE currentState;
    public EVENT stage;
    public StateMachine nextState;

    protected GameObject target;
    protected Transform targetTransform;
    protected NavMeshAgent agent;
    protected NavMeshObstacle obstacle;
    protected Vector3 dest;
    protected Weapon weapon;


    //[SerializeField] private float visionDistance = 35f;
    //[SerializeField] private float visionHeight = 3f;

    public StateMachine(NavMeshAgent agent, NavMeshObstacle obstacle, Weapon weapon)
    {
        this.agent = agent;
        this.obstacle = obstacle;
        this.weapon = weapon;
        stage = EVENT.ENTER;
    }

    public virtual void Enter(){ stage = EVENT.UPDATE; }
    public virtual void Update(){ stage = EVENT.UPDATE; }
    public virtual void Exit(){ stage = EVENT.EXIT; }
    
    public StateMachine Process()
    {
        switch (stage)
        {
            case EVENT.ENTER:
                Enter();
                break;
            case EVENT.UPDATE:
                Update();
                break;
            case EVENT.EXIT:
                Exit();
                return nextState;
        }
        return this;
    }

    protected virtual bool CheckLeftMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 130))
            {
                dest = hit.point;
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    target = hit.transform.gameObject;
                    nextState = new Pursue(agent,obstacle,weapon,target);
                }
                else
                {
                    target = null;
                    nextState = new Move(agent,obstacle,weapon,dest);
                }
                return true;
            }
        }
        return false;
    }

    protected void Chase()
    {
        if (target != null) 
        {
            Vector3 pos = new Vector3(agent.transform.position.x, 10, agent.transform.position.z);
            Vector3 targPos = new Vector3(target.transform.position.x, 10, target.transform.position.z); ;
            Vector3 dir = pos - targPos;
            float offset = weapon.weapon.range + 2f;
            dest = target.transform.position + dir.normalized * offset;
            agent.SetDestination(dest);
        }
    }

    protected bool CheckDistanceToTarg()
    {
        Vector3 pos = new Vector3(agent.transform.position.x, 10, agent.transform.position.z);
        Vector3 targPos = new Vector3(target.transform.position.x, 10, target.transform.position.z); ;
        Vector3 dir = pos - targPos;
        float offset = weapon.weapon.range + 2f;
        dest = target.transform.position + dir.normalized * offset;

        return Vector3.Distance(agent.transform.position, dest) > weapon.weapon.range + 1f;
    }
}
