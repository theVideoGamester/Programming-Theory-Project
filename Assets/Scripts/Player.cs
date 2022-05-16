using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Lots of Inheritance
public class Player : MonoBehaviour
{
    public StateMachine myState;
    public Weapon weapon;
    public bool noisy = false;
    private NavMeshAgent agent;
    private NavMeshObstacle obstacle;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        weapon = gameObject.AddComponent<Sword>();
        myState = new Initialize(agent, obstacle, weapon);
    }

    private void LateUpdate()
    {
        myState = myState.Process();
    }
}
