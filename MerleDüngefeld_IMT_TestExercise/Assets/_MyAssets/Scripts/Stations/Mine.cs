using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Station
{
    //Amount of gold, which one miner mines
    private float mGoldPerMiner;
    //Gold currently held in mine
    private float mGold;

    private float mMuiltiplier = .5f;
    private int mNextAddition = 10;


    private int mMineId;

    public int MineId
    {
        get
        {
            return mMineId;
        }

        set
        {
            mMineId = value;
            //calculate the gold per miner
            mGoldPerMiner = (mMuiltiplier * Level) + mMuiltiplier * MineId;
        }
    }

    public float Gold
    {
        get
        {
            return mGold;
        }

        set
        {
            mGold = value;
        }
    }

    public override void WorkerDone()
    {
        Gold += mGoldPerMiner;
    }
    public override void UpgradeStation()
    {
        Level += 1;

        mMuiltiplier += .2f;
        mGoldPerMiner = (mMuiltiplier * Level) + mMuiltiplier * MineId;

        foreach (Worker miner in WorkerList)
        {
            miner.TimeForCompletion -= .005f;
        }

        if(Level == mNextAddition)
        {
            //spawn new miner
            Loader.Instance.LoadWorker(this);

            mNextAddition = Level * 2;
        }
    }
}
