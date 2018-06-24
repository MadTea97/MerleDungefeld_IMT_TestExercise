using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

    private int mLevel = 1;
    //maybe
    private Vector3 mPosition;

    private int mSpeed;

    private List<Worker> mWorkerList;
    private NPC mManager;

    #region Getter and Setter
    public int Level
    {
        get
        {
            return mLevel;
        }

        set
        {
            mLevel = value;
        }
    }

    public Vector3 Position
    {
        get
        {
            return mPosition;
        }

        set
        {
            mPosition = value;
        }
    }

    public int Speed
    {
        get
        {
            return mSpeed;
        }

        set
        {
            mSpeed = value;
        }
    }

    public List<Worker> WorkerList
    {
        get
        {
            return mWorkerList;
        }

        set
        {
            mWorkerList = value;
        }
    }

    public NPC AssignedManager
    {
        get
        {
            return mManager;
        }

        set
        {
            mManager = value;
        }
    }
    #endregion

    public virtual void Awake()
    {
        mWorkerList = new List<Worker>();
    }
    //Adds a manager to a station and starts an automated work progress
    public virtual void UpgradeStation()
    {
        float costToUpgrade;

        costToUpgrade = Level * 10;

        if (GameMaster.Instance.PlayerGold < costToUpgrade)
            return;

        GameMaster.Instance.PlayerGold -= costToUpgrade;
    }
    public virtual void ApplyBoost()
    {

    }
    public virtual void Work()
    {

    }
    public virtual void WorkerDone()
    {

    }
    //Adds a manager to a station and starts an automated work progress
    public void AddManager()
    {
        float neededGold = 10.0f;

        //calculate price for manager
        //check if the station is a mine
        if(this is Mine)
        {
            if (ObjectManager.Instance.Mines.Contains((Mine)this))
                neededGold = 10 * ObjectManager.Instance.Mines.IndexOf((Mine)this) +1;
        }
        if (mManager != null || GameMaster.Instance.PlayerGold < neededGold)
        {
            Debug.Log("manager already added or not enough money");
            return;
        }
        //subtract money from player
        GameMaster.Instance.PlayerGold -= neededGold;

        //check if player has enough gold for a manager
        Debug.Log("Manager added to " + gameObject.name);
        Loader.Instance.LoadManager(this);

        //start working automatically
        foreach(Worker worker in WorkerList)
        {
            worker.Work(true);
        }
    }
}
