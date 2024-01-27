using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance == null)
                    SetUpInstance();
            }

            return _instance;
        }
    }
    
    protected virtual void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetUpInstance()
    {
        GameObject gameObject = new GameObject();
        gameObject.name = typeof(T).Name;
        _instance       = gameObject.AddComponent<T>();
    }

    private void RemoveDuplicates()
    {
        if (_instance == null)
            _instance = this as T;
        else
            Destroy(gameObject);
        }
}
