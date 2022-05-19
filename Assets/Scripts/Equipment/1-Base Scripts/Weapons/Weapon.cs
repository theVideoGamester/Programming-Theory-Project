using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private SWeapon _weapon;
    public SWeapon weapon{ get { return _weapon; } }

    public Weapon(string name, Dice die, float range)
    {
        _weapon = new SWeapon(name,die,range);
    }

    public int Damage()
    {
        return weapon.GetDamage();
    }
}
