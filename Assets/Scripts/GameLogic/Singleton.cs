﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;

    // Property to access the instance
    public static T Instance
    {
        get
        {
            if (_instance != null) return _instance;
            
            // If the instance doesn't exist, find it in the scene
            _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                var singletonObject = new GameObject(typeof(T).Name);
                _instance = singletonObject.AddComponent<T>();
                Debug.Log($"{typeof(T).Name} instance created."); // Added for debugging purposes
            }
            
            return _instance;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            Debug.Log($"{typeof(T).Name} instance destroyed."); // Added for debugging purposes
            _instance = null;
        }
    }
}

