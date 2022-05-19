using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Lots of Inheritance
public class Player : CombatAgent
{
    [SerializeField]
    private GameObject blinder;

    private bool _canSee = true;
    public bool canSee { set { _canSee = !_canSee; blinder.SetActive(!_canSee); } }
    private void Start()
    {
        myState = new Initialize(agent, obstacle, equipment.weapon);
    }

    public override void Attack()
    {
        if (targetAgent == null)
        {
            myState.nextState = new Idle(agent, obstacle, equipment.weapon);
            myState.stage = StateMachine.EVENT.EXIT;
            return;
        }
        base.Attack();
        Collider[] hitColliders = Physics.OverlapSphere(targetAgent.transform.position, 30f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy"))
            {
                hitCollider.SendMessage("Alert");
            }
        }
    }

    protected override void DestroyTarget()
    {
        base.DestroyTarget();
        myState.nextState = new Idle(agent, obstacle, equipment.weapon);
        myState.stage = StateMachine.EVENT.EXIT;
    }
}
