using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Station
{
    private float mLimit = 50;
    private float mTotalGoldInStation;

    private float mLoadedGold;
    private bool mGoingDown;

    public float TotalGoldInStation
    {
        get
        {
            return mTotalGoldInStation;
        }

        set
        {
            mTotalGoldInStation = value;
        }
    }

    public float LoadedGold
    {
        get
        {
            return mLoadedGold;
        }

        set
        {
            mLoadedGold = value;
        }
    }

    //Collect all the gold
    private void Collect()
    {
        //move towards mine, move down set amount of units as long as count mines

        foreach(Mine mine in ObjectManager.Instance.Mines)
        {
            //check if limit is reached
            if(LoadedGold > mLimit)
            {
                LoadedGold = mLimit;
                break;
            }

            LoadedGold += mine.Gold;
            mine.Gold = 0;
        }
        TotalGoldInStation += LoadedGold;
        Debug.Log("Collected Gold " + LoadedGold);
        LoadedGold = 0;


    }
    public override void WorkerDone()
    {
        Collect();
    }
    public override void UpgradeStation()
    {

        base.UpgradeStation();

        Level += 1;

        WorkerList[0].TimeForCompletion -= .005f;
        mLimit = mLimit * 1.5f;
    }
}
