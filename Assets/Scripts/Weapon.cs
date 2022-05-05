using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public string weaponName;
    [HideInInspector] public float range;

    private void Start()
    {
        initializeWeapon();
    }

    protected virtual void initializeWeapon()
    {
        damage = 0;
        weaponName = "Error: Item not assigned";
        range = 0f;
    }
}
