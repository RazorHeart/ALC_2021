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
        print(Time.time);
    }
}
