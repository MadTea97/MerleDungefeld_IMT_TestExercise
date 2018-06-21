using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : Station
{
    private float mTransportedGold;
    private float mLimit = 100;

    private int mNextAddition = 10;

    private void TransportGold()
    { 
        mTransportedGold = ObjectManager.Instance.Elevator.TotalGoldInStation;
        if (mTransportedGold > mLimit)
        {
            mTransportedGold = mLimit;
            ObjectManager.Instance.Elevator.TotalGoldInStation = ObjectManager.Instance.Elevator.TotalGoldInStation - mLimit;
        }
        else
            ObjectManager.Instance.Elevator.TotalGoldInStation = 0;

    }
    public override void WorkerDone()
    {
        GameMaster.Instance.PlayerGold = mTransportedGold;
        mTransportedGold = 0;
    }
    public override void UpgradeStation()
    {
        Level += 1;

        foreach (Worker transporter in WorkerList)
        {
            transporter.TimeForCompletion -= .005f;
        }

        if (Level == mNextAddition)
        {
            //spawn new miner
            Loader.Instance.LoadWorker(this);

            mNextAddition = Level * 2;
        }
    }
}
