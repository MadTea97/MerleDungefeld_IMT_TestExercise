﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singleton<GameMaster>
{

    private float mPlayerGold;

    public float PlayerGold
    {
        get
        {
            return mPlayerGold;
        }

        set
        {
            mPlayerGold = value;
        }
    }

    private void Awake()
    {
        Instance = this;
        
    }
    private void Start()
    {
        LoadGame();
    }
    //init game
    public void LoadGame()
    {
        //Load all stations
        Loader.Instance.LoadElevator();
        Loader.Instance.LoadTransport();
        Loader.Instance.LoadNewMine();
    }
}
