using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lots of Inheritance
public class Sword : Weapon
{
    //Polyorphism
    protected override void initializeWeapon()
    {
        _damage = 1;
        _weaponName = "Sword";
        _range = 5f;
    }
}

