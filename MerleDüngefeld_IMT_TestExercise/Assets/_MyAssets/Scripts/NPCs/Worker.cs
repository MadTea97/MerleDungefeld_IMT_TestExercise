using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : NPC
{
    //how long does it take for the employee to do their job
    private float mTimeForCompletion = 5f;

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
    public void Work(bool hasManager)
    {
        StartCoroutine(WorkFlow(hasManager));
    }
    IEnumerator WorkFlow(bool hasManager)
    {
        Debug.Log("Start working");

        yield return new WaitForSeconds(TimeForCompletion);
        //Tell station NPC is done
        AssignedStation.WorkerDone();

        Debug.Log("Done Working");

        //Start working again
        if(hasManager)
            Work(hasManager);
        yield return null;
    }
}
