using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : NPC
{
    private Boosts mBoosts;
    private Action BoostAction;

    private void Awake()
    {
        mBoosts = new Boosts();

        //select a random boost for the manager
        BoostAction = mBoosts.BoostList[UnityEngine.Random.Range(0, mBoosts.BoostList.Count - 1)];
    }
    private void ActivateBoost()
    {
        BoostAction.Invoke();
    }
}
