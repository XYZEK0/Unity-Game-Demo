using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItems2 : MonoBehaviour
{
    public static SceneItems2 instance;

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
