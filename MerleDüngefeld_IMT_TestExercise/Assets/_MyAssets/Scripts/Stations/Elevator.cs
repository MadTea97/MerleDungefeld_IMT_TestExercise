using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Station
{
    private float mLimit = 50;
    private float mTotalGoldInStation;

    private float mLoadedGold;
    private bool mGoingDown;
    private float mTimeForToCollect = 2.0f;

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

    //Collect all the gold
    private void Collect()
    {
        //move towards mine, move down set amount of units as long as count mines

        foreach(Mine mine in ObjectManager.Instance.Mines)
        {
            //check if limit is reached
            if(mLoadedGold> mLimit)
            {
                mLoadedGold = mLimit;
                break;
            }

            mLoadedGold += mine.Gold;
            mine.Gold = 0;
        }
        TotalGoldInStation += mLoadedGold;
        mLoadedGold = 0;

        Debug.Log("Collected Gold " + mLoadedGold);

    }
    public override void WorkerDone()
    {
        Collect();
    }
    public override void UpgradeStation()
    {
        Level += 1;

        WorkerList[0].TimeForCompletion -= .005f;
        mLimit = mLimit * 1.5f;
    }
}
