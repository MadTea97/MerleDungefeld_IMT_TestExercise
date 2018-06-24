using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Station
{
    //Amount of gold, which one miner mines
    private float mGoldPerMiner;
    //Gold currently held in mine
    private float mGold;

    private float mMuiltiplier = 1.5f;
    private int mNextAddition = 10;


    private int mMineId;
    //Sets gold per miner, depends on level and id
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
        Debug.Log(Gold + " Gold in mine");
    }
    public override void UpgradeStation()
    {
        base.UpgradeStation();

        Level += 1;

        Debug.Log("Level: " + Level);

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
