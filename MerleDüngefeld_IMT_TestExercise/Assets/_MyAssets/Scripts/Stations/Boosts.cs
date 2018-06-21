using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boosts
{

    private List<Action> mBoostList;

    public List<Action> BoostList
    {
        get
        {
            return mBoostList;
        }

        set
        {
            mBoostList = value;
        }
    }

    public Boosts()
    {
        BoostList = new List<Action>
        {
            SpeedBoost,
            EfficiencyBoost,
            CheapBoost
        };
    }

    public static void SpeedBoost()
    {
        Debug.Log("Activate Speed boost");
    }
    public static void EfficiencyBoost()
    {
        Debug.Log("Activate Efficiency boost");
    }
    public static void CheapBoost()
    {
        Debug.Log("Activate Cheap boost");
    }
}
