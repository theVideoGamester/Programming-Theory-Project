using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
    protected override void initializeWeapon()
    {
        _damage = 1;
        _weaponName = "Bow";
        _range = 20f;
    }
}
