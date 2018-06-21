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
        mWorkerList = new List<NPC>();
        Loader.Instance.LoadWorker(this);
    }
    //Adds a manager to a station and starts an automated work progress
    public void AddManagerToStation()
    {
        foreach(Worker worker in mWorkerList)
        {
            worker.Work(true);
        }
        Loader.Instance.LoadManager(this);
    }
    public virtual void UpgradeStation()
    {

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
}
