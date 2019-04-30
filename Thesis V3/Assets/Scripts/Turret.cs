using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public bool fire;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while(fire)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(bullet, transform.position, transform.rotation);
        }
        
    }
}
