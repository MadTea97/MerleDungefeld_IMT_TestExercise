using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Worker : NPC
{
    //how long does it take for the employee to do their job
    private float mTimeForCompletion = 5f;

    private bool mIsWorking = false;

    public float TimeForCompletion
    {
        get
        {
            return mTimeForCompletion;
        }

        set
        {
            //value shouln't be 0 (this would be way too fast) and under 0  would kill everything
            if (value <= .2)
                return;
            mTimeForCompletion = value;
        }
    }

    private void Awake()
    {

    }

    public override void OnClick()
    {
        //only if no manager is assigned
        if(AssignedStation.AssignedManager == null && !mIsWorking)
            Work(false);
    }
    
    public void Work(bool hasManager)
    {
        StartCoroutine(WorkFlow(hasManager));
    }
    IEnumerator WorkFlow(bool hasManager)
    {
        mIsWorking = true;
        Debug.Log("Start working");

        yield return new WaitForSeconds(TimeForCompletion);
        //Tell station NPC is done
        AssignedStation.WorkerDone();
        mIsWorking = false;
        Debug.Log("Done Working");

        //Start working again
        if(hasManager)
            Work(hasManager);
        yield return null;
    }
}
