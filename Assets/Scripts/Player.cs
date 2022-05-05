using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NavAgent
{
    public bool noisy = false;
    public bool inCombat = false;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 20;
        myWeapon = gameObject.AddComponent<Sword>();
        setAgent();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRightMouseClick();
        RunStateMachine();
    }

    bool CheckRightMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 130))
            {
                startMovement(hit.point);
            }
            else
            {
                return false;
            }


            switch (hit.transform.gameObject.tag)
            {
                case "Ground":
                    myState = states.beginMove;
                    target = null;
                    if (IsInvoking())
                    {
                        CancelInvoke();
                    }
                    break;
                case "Enemy":
                    if (target == null || (!CheckTargetDistance() && target != hit.transform.gameObject))
                    {
                        myState = states.moveToRange;
                        target = hit.transform.gameObject;
                        targetAgent = target.GetComponent<NavAgent>();
                        CancelInvoke();
                    }
                    
                    //Debug.Log(target.name);
                    break;
            }

        }
        return true;
    }
    
    void RunStateMachine()
    {
        switch (myState)
        {
            case states.idle:
                
                break;
            case states.beginMove:
                myState = states.move;
                break;
            case states.move:
                if (endMovement())
                {
                    myState = states.idle;
                }
                break;
            case states.moveToRange:
                if(target == null)
                {
                    myState = states.idle;
                }
                else if (CheckTargetDistance())
                {
                    myState = states.attack;
                    agent.ResetPath();
                }
            break;
            case states.attack:
                noisy = true;
                inCombat = true;
                endMovement();
                transform.LookAt(target.transform);
                if (!IsInvoking()) {
                    InvokeRepeating("Attack", .2f, attackSpeed);
                }
                myState = states.combat;
            break;
            case states.combat:
                if(targetAgent == null)
                {
                    CancelInvoke();
                    myState = states.idle;
                }
                break;
        }
    }
}
