using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //move variables
    public float moveSpeed;
    public float jumpForce;
    //camera, the names are self explanitory
    public float lookSensitivity;
    public float maxLookX;
    public float maxLookY;
    private float rotX;
    //components
    private Camera cam;
    private Rigidbody rb;

  
    void awake()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Verticle") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

}
