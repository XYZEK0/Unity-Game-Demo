using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItems1 : MonoBehaviour
{
    public static SceneItems1 instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
