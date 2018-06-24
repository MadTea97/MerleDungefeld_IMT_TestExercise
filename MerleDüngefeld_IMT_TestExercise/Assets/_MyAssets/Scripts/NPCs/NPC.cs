using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour//, IPointerClickHandler
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
    private void OnMouseDown()
    {
        OnClick();
    }
    public virtual void OnClick()
    {
        
    }
}
