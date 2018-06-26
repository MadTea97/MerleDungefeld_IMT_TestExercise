using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : Station
{
    //limit on what one worker can transport
    [SerializeField]
    private float mLimit = 100;
    //currently transported gold
    private float mTransportedGold;
    //next worker gets added at this level
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

    public float Limit
    {
        get
        {
            return mLimit;
        }

        set
        {
            mLimit = value;
        }
    }

    /// <summary>
    /// sets the gold stats
    /// </summary>
    private void TransportGold()
    { 
        //collect gold from elevator
        TransportedGold = ObjectManager.Instance.Elevator.TotalGoldInStation;
        //check for the limit
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
        //add gold to players gold
        GameMaster.Instance.PlayerGold += TransportedGold;
        TransportedGold = 0;
    }
    public override void UpgradeStation()
    {
        base.UpgradeStation();
        if (GameMaster.Instance.PlayerGold < Level * CostToUpgradeMultiplier)
        {
            return;
        }

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
