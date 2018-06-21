using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Station mAssignedStation;

    public Station AssignedStation
    {
        get
        {
            return mAssignedStation;
        }

        set
        {
            mAssignedStation = value;
        }
    }
}
