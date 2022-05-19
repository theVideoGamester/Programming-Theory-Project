using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StatBlock
{
    //HARDINESS, ATHLETICISM, INTELLECT, WILL, CHARISMA, GRACE
    public int hardiness;
    public int athleticism;
    public int intellect;
    public int will;
    public int charisma;
    public int grace;

    public void initializeValues()
    {
        int def = 10;
        if (hardiness == 0) { hardiness = def; }
        if (athleticism == 0) { athleticism = def; }
        if (intellect == 0) { intellect = def; }
        if (will == 0) { will = def; }
        if (charisma == 0) { charisma = def; }
        if (grace == 0) { grace = def; }
    }
}
