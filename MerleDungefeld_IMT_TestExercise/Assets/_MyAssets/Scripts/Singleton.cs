using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for all singletons
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    public static T mInstance; 

    public static T Instance
    {
        get
        {
            return mInstance;
        }
        set
        {
            //check if instance already exists
            if(mInstance == null)
            {
                DontDestroyOnLoad(value.gameObject);
                mInstance = value;

            }
            else
            {
                //if not, error message
                Debug.Log("Instance of " + typeof(T).ToString() + " already exists, why are you doing this?");
            }
        }
    }
}
