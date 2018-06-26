using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : NPC
{
    //all possible boosts
    private List<Func<float>> mBoostList;
    private Boosts mBoosts;
    //shows if a boost is available
    private bool mBoostAvailable = true;

    //boost function for the manager
    private Func<float> BoostFunction;

    private void Awake()
    {
        mBoosts = new Boosts();
        //set list
        mBoostList = new List<Func<float>>()
            {
                () => mBoosts.SpeedBoost(AssignedStation),
                () => mBoosts.CheapBoost(AssignedStation),
                () => mBoosts.EfficiencyBoost(AssignedStation)
            };

        //Set random boost to manager
        BoostFunction = mBoostList[UnityEngine.Random.Range(0, mBoostList.Count - 1)];

    }
    public override void OnClick()
    {
        //retrun if the boost is on cooldown
        if(!mBoostAvailable)
        {
            Debug.Log("Boost is not available at the moment");
            return;
        }
        //start cooldown routine and execute the boost
        StartCoroutine(WaitTillNextBoostIsAvailable(BoostFunction.Invoke()));
        StartCoroutine(SetBack());
    }
    private IEnumerator SetBack()
    {
        //wait for some time 
        Debug.Log("Boost start");
        yield return new WaitForSeconds(20.0f);
        Debug.Log("Boost end");
        //set the station back to its old stats
        mBoosts.SetBack(AssignedStation);
    }
    /// <summary>
    /// cooldown for the boost
    /// </summary>
    /// <param name="timeUntilNextBoost">cooldown time</param>
    private IEnumerator WaitTillNextBoostIsAvailable(float timeUntilNextBoost)
    {
        mBoostAvailable = false;
        //wait for time in minutes
        yield return new WaitForSeconds(timeUntilNextBoost * 60);

        mBoostAvailable = true;
    }

}
