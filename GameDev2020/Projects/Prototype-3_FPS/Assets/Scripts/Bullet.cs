using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    public float lifeTime;

    private float shootTime;

    void OnEnable()
    {
        shootTime =Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifeTime)
            gameObject.SetActive(false);

        

    }

   // did we hit the player? or did we hit the enemy
     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        //Swap the player controller for the enemy
        else if(other.CompareTag("Enemy"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        
        //disable the bullet
        gameObject.SetActive(false); 
    }

}
