using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DICE
{
    D2 = 2, D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20, D100 = 100
}

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
