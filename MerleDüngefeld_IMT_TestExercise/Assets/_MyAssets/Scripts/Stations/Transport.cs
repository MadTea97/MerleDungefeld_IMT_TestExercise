using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : Station
{
    private float mTransportedGold;
    private float mLimit = 100;

    private int mNextAddition = 10;

    public float TransportedGold
    {
        get
        {
            return mTransportedGold;
        }

        set
        {
            mTransportedGold = value;
        }
    }

    private void TransportGold()
    { 
        TransportedGold = ObjectManager.Instance.Elevator.TotalGoldInStation;
        if (TransportedGold > mLimit)
        {
            TransportedGold = mLimit;
            ObjectManager.Instance.Elevator.TotalGoldInStation = ObjectManager.Instance.Elevator.TotalGoldInStation - mLimit;
        }
        else
            ObjectManager.Instance.Elevator.TotalGoldInStation = 0;

    }
    public override void WorkerDone()
    {
        TransportGold();
        Debug.Log("Transport done");
        GameMaster.Instance.PlayerGold += TransportedGold;
        TransportedGold = 0;
    }
    public override void UpgradeStation()
    {
        base.UpgradeStation();

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
