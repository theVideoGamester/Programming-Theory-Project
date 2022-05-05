using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    protected override void initializeWeapon()
    {
        damage = 1;
        weaponName = "Sword";
        range = 5f;
    }
}

