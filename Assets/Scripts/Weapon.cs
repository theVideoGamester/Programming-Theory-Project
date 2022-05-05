using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Parent Class. Contains Stats
public class Weapon : MonoBehaviour
{
    //Encapsulate
    protected int _damage;
    public int damage { get { return _damage; } }

    protected string _weaponName;
    public string weaponName { get { return _weaponName; } }

    protected float _range;
    public float range { get { return _range; } }

    private void Start()
    {
        initializeWeapon();
    }

    //Polymorphism and Abstraction
    protected virtual void initializeWeapon()
    {
        _damage = 0;
        _weaponName = "Error: Item not assigned";
        _range = 0f;
    }
}
