using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance;   
    private void Awake()
    {
        if (Singleton.Instance == null)
        {
            Singleton.Instance = this;
           
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
