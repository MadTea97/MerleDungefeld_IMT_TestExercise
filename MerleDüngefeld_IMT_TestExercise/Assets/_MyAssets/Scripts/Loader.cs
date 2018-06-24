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

        mine.transform.position = new Vector3(0, -ObjectManager.Instance.Mines.Count);

        //Set a worker into the mine
        LoadWorker(mine.GetComponent<Station>());
    }
    public void LoadElevator()
    {
        //Create new object
        GameObject elevator = Instantiate(ElevatorPrefab);
        //Pass object to object manager
        ObjectManager.Instance.Elevator = elevator.GetComponent<Elevator>();

        elevator.transform.position = new Vector3(-2.5f, -3f);

        //Set a worker into the elevator
        LoadWorker(elevator.GetComponent<Station>());
    }
    public void LoadTransport()
    {
        //Create new object
        GameObject transport = Instantiate(TransportPrefab);
        //Pass object to object manager
        ObjectManager.Instance.Transport = transport.GetComponent<Transport>();

        transport.transform.position = new Vector3(2, 0);

        //Set a worker into the transport
        LoadWorker(transport.GetComponent<Station>());
    }
    public void LoadManager(Station assignedStation)
    {
        GameObject manager = Instantiate(ManagerPrefab);

        //set manager to station
        manager.transform.parent = assignedStation.transform;
        assignedStation.AssignedManager = manager.GetComponent<Manager>();

        manager.GetComponent<Manager>().AssignedStation = assignedStation;

        //Add to the object manager
        ObjectManager.Instance.Manager.Add(manager.GetComponent<Manager>());

        //Set position
        manager.transform.position = new Vector3(assignedStation.transform.position.x -.5f, assignedStation.transform.position.y);
    }
    public void LoadWorker(Station assignedStation)
    {
        GameObject worker = Instantiate(WorkerPrefab);

        //set worker to station
        worker.transform.parent = assignedStation.transform;
        assignedStation.WorkerList.Add(worker.GetComponent<Worker>());
        worker.GetComponent<Worker>().AssignedStation = assignedStation;

        ObjectManager.Instance.Worker.Add(worker.GetComponent<Worker>());

        worker.transform.position = assignedStation.transform.position;

    }
}
