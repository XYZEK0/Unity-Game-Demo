using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerController playerController = null;

    public float playerSlowValue;

    
    void FixedUpdate()
    {
       

        float horizontalVelocity = playerController.playerRB.velocity.x;
            horizontalVelocity += Input.GetAxisRaw("Horizontal");
            horizontalVelocity *= Mathf.Pow(1 - playerController.horizontalDamping, Time.deltaTime * playerSlowValue);
            playerController.playerRB.velocity = new Vector2(horizontalVelocity, playerController.playerRB.velocity.y);
    }
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Space) && playerController.isOnground )
        {
            playerController.playerRB.AddForce(Vector2.up * playerController.jumpSpeed);
        }
    }
}