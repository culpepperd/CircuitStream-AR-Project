using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creating a Singleton
public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
