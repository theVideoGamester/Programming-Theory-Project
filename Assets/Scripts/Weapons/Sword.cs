using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    //Polyorphism
    protected override void initializeWeapon()
    {
        _damage = 5;
        _weaponName = "Sword";
        _range = 2f;
    }
}