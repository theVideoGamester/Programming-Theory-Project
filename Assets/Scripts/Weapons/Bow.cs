using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
    protected override void initializeWeapon()
    {
        damage = 1;
        weaponName = "Bow";
        range = 25f;
    }
}
