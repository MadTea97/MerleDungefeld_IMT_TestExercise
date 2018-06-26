using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//All variables from stations that are changed during an active boost
struct Stats
{
    float currentWorkerSpeed;
    float currentEfficiency;
    float currentUpgradeMultiplier;

    public float CurrentWorkerSpeed
    {
        get
        {
            return currentWorkerSpeed;
        }

        set
        {
            currentWorkerSpeed = value;
        }
    }

    public float CurrentEfficiency
    {
        get
        {
            return currentEfficiency;
        }

        set
        {
            currentEfficiency = value;
        }
    }

    public float CurrentUpgradeMultiplier
    {
        get
        {
            return currentUpgradeMultiplier;
        }

        set
        {
            currentUpgradeMultiplier = value;
        }
    }
}

public class Boosts
{

    private Stats mCurrentStats;
    
    /// <summary>
    /// Speeds up the worker in the station
    /// </summary>
    /// <param name="stationToBoost"></param>
    /// <returns>Returns the time until the next boost</returns>
    public float SpeedBoost(Station stationToBoost)
    {
        Debug.Log("Activate Speed boost");
        SaveStats(stationToBoost);

        foreach (Worker worker in stationToBoost.WorkerList)
        {
            worker.TimeForCompletion -= .5f;
        }

        return 5.0f;
    }
    /// <summary>
    /// The station can mine/transport more gold at once
    /// </summary>
    /// <param name="stationToBoost"></param>
    /// <returns>Returns the time until the next boost</returns>
    public float EfficiencyBoost(Station stationToBoost)
    {
        Debug.Log("Activate Efficiency boost");
        SaveStats(stationToBoost);

        if (stationToBoost is Mine)
        {
            Mine mine = (Mine)stationToBoost;
            mine.GoldPerMiner = mine.GoldPerMiner *2;
        }
        else if (stationToBoost is Elevator)
        {
            Elevator elevator = (Elevator)stationToBoost;
            elevator.Limit = elevator.Limit *2;
        }
        else if (stationToBoost is Transport)
        {
            Transport transport = (Transport)stationToBoost;
            transport.Limit = transport.Limit * 2;
        }
        return 5.0f;
    }
    /// <summary>
    /// The upgrade costs are reduces
    /// </summary>
    /// <param name="stationToBoost"></param>
    /// <returns>Returns the time until the next boost</returns>
    public float CheapBoost(Station stationToBoost)
    {
        Debug.Log("Activate Cheap boost");
        SaveStats(stationToBoost);
        stationToBoost.CostToUpgradeMultiplier = stationToBoost.CostToUpgradeMultiplier /2;

        return 5.0f;
    }
    /// <summary>
    /// Sets a station back to its old stats
    /// </summary>
    /// <param name="stationToSetBack"></param>
    public void SetBack(Station stationToSetBack)
    {
        foreach(Worker worker in stationToSetBack.WorkerList)
        {
            worker.TimeForCompletion = mCurrentStats.CurrentWorkerSpeed;
        }
        stationToSetBack.CostToUpgradeMultiplier = mCurrentStats.CurrentUpgradeMultiplier;

        if (stationToSetBack is Mine)
        {
            Mine mine = (Mine)stationToSetBack;
            mine.GoldPerMiner = mCurrentStats.CurrentEfficiency;
        }
        else if (stationToSetBack is Elevator)
        {
            Elevator elevator = (Elevator)stationToSetBack;
            elevator.Limit = mCurrentStats.CurrentEfficiency;
        }
        else if (stationToSetBack is Transport)
        {
            Transport transport = (Transport)stationToSetBack;
            transport.Limit = mCurrentStats.CurrentEfficiency;
        }
    }
    /// <summary>
    /// Saves all current stats from a station
    /// </summary>
    /// <param name="stationToSave"></param>
    private void SaveStats(Station stationToSave)
    {
        mCurrentStats = new Stats
        {
            CurrentWorkerSpeed = stationToSave.WorkerList[0].TimeForCompletion,
            CurrentUpgradeMultiplier = stationToSave.CostToUpgradeMultiplier
        };

        if (stationToSave is Mine)
        {
            Mine mine = (Mine)stationToSave;
            mCurrentStats.CurrentEfficiency = mine.GoldPerMiner;
        }
        else if(stationToSave is Elevator)
        {
            Elevator elevator = (Elevator)stationToSave;
            mCurrentStats.CurrentEfficiency = elevator.Limit;
        }
        else if (stationToSave is Transport)
        {
            Transport transport = (Transport)stationToSave;
            mCurrentStats.CurrentEfficiency = transport.Limit;
        }
    }
}
