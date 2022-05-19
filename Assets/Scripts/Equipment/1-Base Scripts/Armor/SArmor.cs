using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SArmor 
{
    public string armorName;
    public int ac;

    public SArmor(string _armorName, int _ac)
    {
        armorName = _armorName;
        ac = _ac;
    }
}
