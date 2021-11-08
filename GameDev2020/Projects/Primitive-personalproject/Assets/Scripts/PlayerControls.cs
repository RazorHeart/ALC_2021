using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public float hInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
            Jump();
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * hInput);
    }

    void Jump()
    {   
        // cast ray to ground
        Ray ray = new Ray(transform.position, Vector3.down);
        //checks ray to determine if on the ground
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

}
