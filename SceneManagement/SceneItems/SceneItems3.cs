using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItems3 : MonoBehaviour
{
    public static SceneItems3 instance;

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
