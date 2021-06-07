using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool czyPokazal = false;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    private void Start()
    {
        /*switch (sceneName)
        {
            case "Scene1":
                Debug.Log("Scena pierwsza");
                break;
            case "Scene2":
                Debug.Log("Scena druga");
                break;
            case "Scene3":
                Debug.Log("Scena trzecia");
                break;
            default:
                Debug.Log("Jakieś błędy tutaj są");
                break;
        }*/
    }
}