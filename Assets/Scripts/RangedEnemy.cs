using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    { 
        myState = new EInitialize(agent, obstacle, weapon);
        weapon = gameObject.AddComponent<Bow>();
    }
}
