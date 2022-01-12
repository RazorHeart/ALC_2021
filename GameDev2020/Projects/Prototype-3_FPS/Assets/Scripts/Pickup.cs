using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickType
{
    Health,

    Ammo
}

public class Pickup : MonoBehaviour
{

    public PickType type;
    public int value;


    [Header ("Bobbing Anim")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    public AudioClip pickupSfx;
    public AudioSource audioSource;
    private Vector3 startPos;
    private bool bobbingUp;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)    
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            switch(type)
            {
                case PickType.Health:
                player.GiveHealth(value);
                break;
                
                case PickType.Ammo:
                player.GiveAmmo(value);
                break;
            }
        }
        other.GetComponent<AudioSource>().PlayOneShot(pickupSfx);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //rotating
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        //bob up and down
        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight /2, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }
}
