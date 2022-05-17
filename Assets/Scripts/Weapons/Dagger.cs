using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{
    //Polyorphism
    protected override void initializeWeapon()
    {
        _damage = 1;
        _weaponName = "Dagger";
        _range = 2f;
    }
}