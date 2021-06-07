using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public PlayerController playerController = null;
   
    public Animator playerAnim = null;

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetFloat("Speed", playerController.playerRB.velocity.sqrMagnitude);
        
    }
}
