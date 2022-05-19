using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public SArmor armor;

    public Armor(string armorName, int ac)
    {
        this.armor = new SArmor(armorName, ac);
    }
}
