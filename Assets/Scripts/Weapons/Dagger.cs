using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{
    Dagger() : base("Dagger", new Dice(1, DICE.D4), 2f)
    {

    }

    Dagger(string name, Dice dice, float range) : base(name, dice, range)
    {

    }
}