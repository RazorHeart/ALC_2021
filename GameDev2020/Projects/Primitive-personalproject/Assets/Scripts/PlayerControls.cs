using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //player movement
    public float moveSpeed;
    public float jumpForce;
    public float moveSpeedInAir;
    public float originalMoveSpeed;
    //ground check
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    //Non-Stick Player?
    private float moveVelocity;
    //for animation use later or drop
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        originalMoveSpeed = moveSpeed;
        //also for animation
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& grounded)
            {
                Jump();
            }

        moveVelocity = 0f;

        if(grounded == false)
            {
                moveSpeed = moveSpeedInAir;
            }
        if(grounded == true)
            {
                moveSpeed = originalMoveSpeed;
            }

        if(Input.GetKey (KeyCode.D))
            {
                moveVelocity = moveSpeed;
                //animator.SetBool("isWalking", true);
            }
        else if (Input.GetKeyUp(KeyCode.D))
            {
                //animator.SetBool("isWalking", false);
            }
        if(Input.GetKey (KeyCode.A))
            {
                moveVelocity = -moveSpeed;
                //animator.SetBool("isWalking", true);
            }
        else if (Input.GetKeyUp(KeyCode.A))
            {
                //animator.SetBool("isWalking", false);
            }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void Jump()
    {   
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        //animator.SetBool("isJumping",true);
    }

}
