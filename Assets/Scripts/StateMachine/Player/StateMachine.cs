using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine
{
    public enum STATE
    {
        INITIALIZE,IDLE, PATROL, ATTACK, PURSUE, MOVING
    }

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    public STATE currentState;
    protected EVENT stage;
    protected GameObject target;
    protected Transform targetTransform;
    protected StateMachine nextState;
    protected NavMeshAgent agent;
    protected NavMeshObstacle obstacle;
    protected Vector3 dest;
    protected Weapon weapon;


    [SerializeField] private float visionDistance = 35f;
    [SerializeField] private float hearingDistance = 60f;
    [SerializeField] private float visionHeight = 3f;

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

    protected bool CheckLeftMouseClick()
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
}
