using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    public float turnspeed = 159999.0f;

    private float hInput;
    private float vInput;

    public float xRange = 10.01f;
    public float yRange = 4.5f;

    public GameObject projectile;
    public Transform firepoint;

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
    //player controlls
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        transform.Rotate(Vector3.back, turnspeed * Time.deltaTime * hInput);

    //wall colliders (note: if you swap the negatives you get pacman scrolling)
        //right
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }
        //left
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        //top
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x,yRange,transform.position.z);
        }
        //bottom
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x,-yRange,transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, firepoint.transform.position, firepoint.transform.rotation);
        }

    }
}
