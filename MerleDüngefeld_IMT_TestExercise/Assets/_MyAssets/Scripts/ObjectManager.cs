using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The objectManager has a reference for all objects
public class ObjectManager : Singleton<ObjectManager>
{

    //Stations
    private List<Mine> mMines;
    private Elevator mElevator;
    private Transport mTransport;

    //NPCs
    private List<Manager> mManager;
    private List<Worker> mWorker;

    public Elevator Elevator
    {
        get
        {
            return mElevator;
        }

        set
        {
            mElevator = value;
        }
    }
    public Transport Transport
    {
        get
        {
            return mTransport;
        }

        set
        {
            mTransport = value;
        }
    }

    public List<Mine> Mines
    {
        get
        {
            return mMines;
        }

        set
        {
            mMines = value;
        }
    }

    public List<Manager> Manager
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

    public List<Worker> Worker
    {
        get
        {
            return mWorker;
        }

        set
        {
            mWorker = value;
        }
    }

    private void Awake()
    {
        Instance = this;
        mMines = new List<Mine>();
        mManager = new List<global::Manager>();
        mWorker = new List<global::Worker>();
    }
}
