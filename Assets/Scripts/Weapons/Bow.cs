using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
    Bow() : base("Bow", new Dice(1, DICE.D4), 20f)
    {

    }

    Bow(string name, Dice dice, float range) : base(name, dice, range)
    {

    }
}
