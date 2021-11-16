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


    // Start is called before the first frame update
    void Start()
    {
        print("start");
    }

    void OnTriggerEnter(Collider other)    
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

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
