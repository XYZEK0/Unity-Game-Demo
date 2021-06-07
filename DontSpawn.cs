using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontSpawn : MonoBehaviour
{
    public bool wasPickedUp = false;

    void Start()
    {
        if(wasPickedUp)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
        else
        {
            //gameObject.SetActive(true);
        }
    }
}
