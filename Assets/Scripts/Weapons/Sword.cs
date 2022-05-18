using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    Sword() : base("Sword", new Dice(1, DICE.D6), 2f)
    {

    }

    Sword(string name, Dice dice, float range):base(name, dice, range)
    {

    }
}