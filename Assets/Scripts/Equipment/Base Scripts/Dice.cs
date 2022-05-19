using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Dice
{
    public static DICE die;
    public static int dieCount;

    public Dice(int _dieCount, DICE _die)
    {
        die = _die;
        dieCount = _dieCount;
    }

    public int RollDice()
    {
        int total = 0;

        for (int i = 0; i < dieCount; i++)
        {
            total += Random.Range(0, (int)die) + 1;
        }

        return total;
    }
}
