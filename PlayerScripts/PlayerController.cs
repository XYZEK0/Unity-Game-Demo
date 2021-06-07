using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimController))]

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private Transform groundCheckL = null;
    [SerializeField] private Transform groundCheckR = null;
    [SerializeField] private Inventory inventory = null;



    public float horizontalDamping;
    public float jumpSpeed;
    public float ladderCheckDistance;
    public float ladderClimbSpeed;

    public bool isOnground;
    public bool isClimbing;


    private Vector3 right;
    private Vector3 left;

    [HideInInspector] public float moveX;

    public Rigidbody2D playerRB;

    private void Awake()
    {
    }

    void Start()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        right = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        left = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void Update()
    {
        CheckifOnGround();
        CheckLocalScale();
        CheckifLadder();


        if (isClimbing)
        {
            float verticalVelocity = playerRB.velocity.y;
            verticalVelocity += Input.GetAxisRaw("Vertical");
            verticalVelocity *= Mathf.Pow(1 - horizontalDamping, Time.deltaTime * ladderClimbSpeed);
            playerRB.velocity = new Vector2(playerRB.velocity.x, verticalVelocity);

            playerRB.gravityScale = 0;
        }
        else
        {
            playerRB.gravityScale = 2;

        }

    }


    private void CheckifLadder()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, ladderCheckDistance, 1 << 9);

        if (hit.collider != null)
        {
            isClimbing = true;
        }
        else isClimbing = false;
    }


    private void CheckLocalScale()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) transform.localScale = right;
        else if (Input.GetAxisRaw("Horizontal") < 0) transform.localScale = left;
    }

    private void CheckifOnGround()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << 8) || Physics2D.Linecast(transform.position, groundCheckL.position, 1 << 8) || Physics2D.Linecast(transform.position, groundCheckR.position, 1 << 8))
        {

            StopAllCoroutines();
            isOnground = true;
            horizontalDamping = 0.6f;
        }
        else
        {

            StartCoroutine(groundTimer(0.05f));
        }


    }

    private IEnumerator groundTimer(float time)
    {

        yield return new WaitForSeconds(time);
        isOnground = false;

    }


}