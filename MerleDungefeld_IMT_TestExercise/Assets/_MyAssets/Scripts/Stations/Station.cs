using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for all stations
public class Station : MonoBehaviour
{
    [SerializeField]
    float costToUpgradeMultiplier;

    //current level
    private int mLevel = 1;

    //assigned worker
    private List<Worker> mWorkerList;
    //assigned manager
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

    public float CostToUpgradeMultiplier
    {
        get
        {
            return costToUpgradeMultiplier;
        }
        set
        {
            costToUpgradeMultiplier = value;
        }
    }
    #endregion

    public virtual void Awake()
    {
        mWorkerList = new List<Worker>();
    }
    public virtual void UpgradeStation()
    {
        float costToUpgrade;
        //calculate the upgrade costs
        costToUpgrade = Level * CostToUpgradeMultiplier;
        Debug.Log(costToUpgrade + " cost to upgrade");
       //check if player has enough gold
        if (GameMaster.Instance.PlayerGold < costToUpgrade)
        {
            Debug.Log("Not enough money to upgrade");
            return;
        }

        Debug.Log("Level: " + Level);
        Level += 1;
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
    /// <summary>
    /// Adds a a manager to a station and starts an automated work progress (Used by the UI)
    /// </summary>
    public void AddManager()
    {
        Debug.Log("Trying to add manager to " + gameObject.name);
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
