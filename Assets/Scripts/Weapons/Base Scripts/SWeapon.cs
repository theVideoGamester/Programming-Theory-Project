using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SWeapon
{
    public string weaponName;
    public Dice damage;
    public float range;

    public SWeapon(string _weaponName, Dice _damage, float _range)
    {
        weaponName = _weaponName;
        damage = _damage;
        range = _range;
    }

    public int GetDamage()
    {
        return damage.RollDice();
    }
}

