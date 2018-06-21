using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The loader is responsible for loading all objects
public class Loader : Singleton<Loader>
{
    [SerializeField]
    GameObject MinePrefab;
    [SerializeField]
    GameObject ElevatorPrefab;
    [SerializeField]
    GameObject TransportPrefab;
    [SerializeField]
    GameObject ManagerPrefab;
    [SerializeField]
    GameObject WorkerPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadNewMine()
    {
        //Create new object
        GameObject mine = Instantiate(MinePrefab);
        //Pass object to object manager
        ObjectManager.Instance.Mines.Add(mine.GetComponent<Mine>());
        //Set the id for the mine
        mine.GetComponent<Mine>().MineId = ObjectManager.Instance.Mines.Count;
    }
    public void LoadElevator()
    {
        //Create new object
        GameObject elevator = Instantiate(ElevatorPrefab);
        //Pass object to object manager
        ObjectManager.Instance.Elevator = elevator.GetComponent<Elevator>();
    }
    public void LoadTransport()
    {
        //Create new object
        GameObject transport = Instantiate(TransportPrefab);
        //Pass object to object manager
        ObjectManager.Instance.Transport = transport.GetComponent<Transport>();
    }
    public void LoadManager(Station assignedStation)
    {
        GameObject manager = Instantiate(ManagerPrefab);

        //set manager to station
        manager.transform.parent = assignedStation.transform;
        assignedStation.AssignedManager = manager.GetComponent<Manager>();

        ObjectManager.Instance.Manager.Add(manager.GetComponent<Manager>());
    }
    public void LoadWorker(Station assignedStation)
    {
        GameObject worker = Instantiate(WorkerPrefab);

        //set manager to station
        worker.transform.parent = assignedStation.transform;
        assignedStation.WorkerList.Add(worker.GetComponent<Worker>());

        ObjectManager.Instance.Worker.Add(worker.GetComponent<Worker>());
    }
}
