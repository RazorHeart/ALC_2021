using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //player movement
    public float moveSpeed;
    public float jumpForce;
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

        if(Input.GetKey (KeyCode.D))
            {
                moveVelocity = moveSpeed;
                animator.SetBool("isWalking", true);
            }
        else if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("isWalking", false);
            }
        if(Input.GetKey (KeyCode.A))
            {
                moveVelocity = -moveSpeed;
                animator.SetBool("isWalking", true);
            }
        else if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("isWalking", false);
            }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<RigidBody2D>().velocity.y);
    }

    public void Jump()
    {   
        GetComponent<RigidBody2D>().velocity = new Vector2(GetComponent<RigidBody2D>().velocity.x, jumpForce);
        animator.SetBool("isJumping",true);
    }

}
