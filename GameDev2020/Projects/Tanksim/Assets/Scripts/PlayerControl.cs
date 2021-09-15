using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public float speed = 10.0f;
    public float turnspeed;
    //left right turnspeed
    public float hInput;
    //forward back
    public float vInput;

    // Update is called once per frame
    void Update()
    {
        //getting inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        
        //makes vehicle go
        transform.Rotate(Vector3.up, turnspeed * hInput * Time.deltaTime);
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
    }
}
