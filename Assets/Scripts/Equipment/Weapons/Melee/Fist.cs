using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Weapon
{
    Fist() : base("Fist", new Dice(1, DICE.D2), 2f)
    {

    }
}
