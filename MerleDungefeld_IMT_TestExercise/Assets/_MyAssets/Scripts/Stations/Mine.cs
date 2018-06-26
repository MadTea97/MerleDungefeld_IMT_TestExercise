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

    #region Getter and Setter
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

    public float GoldPerMiner
    {
        get
        {
            return mGoldPerMiner;
        }

        set
        {
            mGoldPerMiner = value;
        }
    }
    #endregion

    public override void WorkerDone()
    {
        Gold += mGoldPerMiner;
    }
    public override void UpgradeStation()
    {
        base.UpgradeStation();
        //check again, base class return does not work
        if (GameMaster.Instance.PlayerGold < Level * CostToUpgradeMultiplier)
        {
            return;
        }
        //calculate new gold per miner income
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
