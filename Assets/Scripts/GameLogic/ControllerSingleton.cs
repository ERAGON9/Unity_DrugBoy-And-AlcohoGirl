using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerSingleton<T> : Controller where T: MonoBehaviour
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
            }
                
            // DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
