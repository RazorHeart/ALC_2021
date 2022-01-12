using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public ObjectPooling bulletPool;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;
    public AudioClip shootSfx;
    public AudioSource audioSource;
    void Awake()
    {
        if(GetComponent<PlayerController>())
        {
            isPlayer = true;
            
        }
        audioSource = GetComponent<AudioSource>();
    }

    //Can we shoot?
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            {
                return true;
            }
        }

        return false;

    }

    //grabs bullet from the bullet pool created by Objectpooling script
    public void Shoot()
    {
        audioSource.PlayOneShot(shootSfx);
        lastShootTime = Time.time;
        curAmmo --;

        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;


        //Set Velocity of bulletprojectile
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
        if(isPlayer)
            GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
