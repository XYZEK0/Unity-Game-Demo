using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : SceneController
{

    [SerializeField] private Transform playerTrans = null;
    [SerializeField] private Vector3 spawnPos;
    
   public override void Start()
   {
        if(prevScene == "Scene2" || prevScene == "Scene3")
        {
            playerTrans.position = spawnPos;
        }
        base.Start();
    }

}
