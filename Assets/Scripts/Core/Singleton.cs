using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BaseApps;

public class Singleton : MonoBehaviour
{

    public static Singleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (Instance == null)
            {
                Instantiate(Instance);
                Debug.Log("error when trying to create singleton");
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
