using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
                //if not, create a new object
                //if(!value.gameObject)
                //{
                //    GameObject singleton = new GameObject
                //    {
                //        name = "singleton " + typeof(T).ToString()
                //    };
                //    mInstance = singleton.AddComponent<T>();
                //}
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
