using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //public bool fire;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // StartCoroutine("Shoot");
       if (Time.time > nextFire)
       {
        nextFire = Time.time + fireRate;
        Instantiate (bullet,bulletSpawn.position, bulletSpawn.rotation);
       }
       
    }

   /*  IEnumerator Shoot()
    {
        while(fire)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(bullet, transform.position, transform.rotation);
        }
        
    }*/
}
