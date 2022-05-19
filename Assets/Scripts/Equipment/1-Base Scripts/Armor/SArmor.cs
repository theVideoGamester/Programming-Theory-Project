using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SArmor 
{
    [SerializeField]
    public string armorName;
    [SerializeField]
    public int ac;

    public SArmor(string _armorName, int _ac)
    {
        armorName = _armorName;
        ac = _ac;
    }
}
