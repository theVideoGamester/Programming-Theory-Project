using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatBlock
{
    //HARDINESS, ATHLETICISM, INTELLECT, WILL, CHARISMA, GRACE
    [Range(0,20)]
    public int hardiness;
    [Range(0, 20)]
    public int athleticism;
    [Range(0, 20)]
    public int intellect;
    [Range(0, 20)]
    public int will;
    [Range(0, 20)]
    public int charisma;
    [Range(0, 20)]
    public int grace;

    [HideInInspector]
    public int hardinessBonus;
    [HideInInspector]
    public int athleticismBonus;
    [HideInInspector]
    public int intellectBonus;
    [HideInInspector]
    public int willBonus;
    [HideInInspector]
    public int charismaBonus;
    [HideInInspector]
    public int graceBonus;

    public void initializeValues()
    {
        int def = 10;
        if (hardiness == 0) { hardiness = def; }
        if (athleticism == 0) { athleticism = def; }
        if (intellect == 0) { intellect = def; }
        if (will == 0) { will = def; }
        if (charisma == 0) { charisma = def; }
        if (grace == 0) { grace = def; }

        hardinessBonus = hardiness - def;
        athleticismBonus = athleticism - def;
        intellectBonus = intellect - def;
        willBonus = will - def;
        charismaBonus = charisma - def;
        graceBonus = grace - def;
    }
}
