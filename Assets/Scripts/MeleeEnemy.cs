using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    void Start()
    {
        myState = new EInitialize(agent, obstacle, weapon);
        weapon = gameObject.AddComponent<Dagger>();
    }
}
