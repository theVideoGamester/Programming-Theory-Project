using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lots of Inheritance
public class Bow : Weapon
{
    //Polymorphism
    protected override void initializeWeapon()
    {
        _damage = 1;
        _weaponName = "Bow";
        _range = 25f;
    }
}
