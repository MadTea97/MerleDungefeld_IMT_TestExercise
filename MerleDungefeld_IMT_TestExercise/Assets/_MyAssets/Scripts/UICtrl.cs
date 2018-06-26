using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI controller - shows info
public class UICtrl : MonoBehaviour
{
    [SerializeField]
    Text[] InfoTexts;

    private void Update()
    {
        InfoTexts[0].text = "Total Gold: " + GameMaster.Instance.PlayerGold;
        InfoTexts[1].text = "Gold being transported: " + ObjectManager.Instance.Transport.TransportedGold;
        InfoTexts[2].text = "Currently loaded gold in elevator: " + ObjectManager.Instance.Elevator.LoadedGold;
        InfoTexts[3].text = "Total gold stored in elevator: " + ObjectManager.Instance.Elevator.TotalGoldInStation;
        InfoTexts[4].text = "Gold|Worker in mine 1: " + ObjectManager.Instance.Mines[0].Gold + " | " + ObjectManager.Instance.Mines[0].WorkerList.Count;
        if(ObjectManager.Instance.Mines.Count>1)
            InfoTexts[5].text = "Gold|Worker in mine 2: " + ObjectManager.Instance.Mines[1].Gold + " | " + ObjectManager.Instance.Mines[1].WorkerList.Count;
        if (ObjectManager.Instance.Mines.Count > 2)
            InfoTexts[6].text = "Gold|Worker in mine 3: " + ObjectManager.Instance.Mines[2].Gold + " | " + ObjectManager.Instance.Mines[2].WorkerList.Count;
    }
    public void OnAddNewMine()
    {
        //Check if player has enough money
        if (GameMaster.Instance.PlayerGold >= ObjectManager.Instance.Mines.Count * 10)
        {
            //subtract money from players gold
            GameMaster.Instance.PlayerGold -= ObjectManager.Instance.Mines.Count * 10;
            //Load new mine if enough money
            Loader.Instance.LoadNewMine();
        }
        else
            Debug.Log("Not enough money for a new mine, you need " + ObjectManager.Instance.Mines.Count * 10 + " Gold");
    }
}
