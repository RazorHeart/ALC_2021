using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public int currentHP;

    public int maxHP;

    [Header("Movement")] 
    public float moveSpeed;
    public float jumpForce;
    //camera, the names are self explanitory
    [Header("CamControls")]
    public float lookSensitivity;
    public float minLookX;
    public float maxLookX;
    private float rotX;
    //components
    private Camera cam;
    private Rigidbody rb;

    private Weapon weapon;

    //first thing to be done
    void Awake()
    {   
        //get the components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();

        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
            Jump();
        //fire conditional
        if(Input.GetButton("Fire1"))
        {   
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        //applyling movement
        Vector3 dir = transform.right * x + transform.forward * z;
        //jump direction
        dir.y = rb.velocity.y;
        //apply direction to camera movement
        rb.velocity = dir;
    }

    void Jump()
    {   
        // cast ray to ground
        Ray ray = new Ray(transform.position, Vector3.down);
        //checks ray to determine if on the ground
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }



    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        //clamp the vertical rotation of the camera
        rotX =  Mathf.Clamp(rotX, minLookX, maxLookX);

        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;


    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        
        if(currentHP <= 0)
            Die();
    }

    void Die()
    {
        print("you die now");
    }

}
