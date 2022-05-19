using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipment
{
    public Weapon weapon;
    public AHelmets helmet;
    public AChests chest;
    public AGloves gloves;
    public APants pants;
    public AShoes shoes;

    public void InitArmor(GameObject obj)
    {
        if (weapon == null) { weapon = obj.AddComponent<Fist>(); }
        if (helmet == null) { helmet = obj.AddComponent<BareHeaded>(); }
        if (chest == null) { chest = obj.AddComponent<BareChested>(); }
        if (gloves == null) { gloves = obj.AddComponent<BareHanded>(); }
        if (pants == null) { pants = obj.AddComponent<BareBottomed>(); }
        if (shoes == null) { shoes = obj.AddComponent<BareFooted>(); }
    }

    public int GetAC()
    {
        int ac = 6;
        ac += helmet.armor.ac;
        ac += chest.armor.ac;
        ac += gloves.armor.ac;
        ac += pants.armor.ac;
        ac += shoes.armor.ac;

        return ac;
    }
}
