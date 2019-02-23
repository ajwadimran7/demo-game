using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public GameObject firepoint;
    public List<GameObject> vfx = new List<GameObject> ();

    private GameObject objectToSpawn;

    private float timeToFire = 0f;
    public float fireRate;

    void Start()
    {
        objectToSpawn = vfx[0];
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > timeToFire) {
            GameObject vfx;
            if(firepoint) {
                vfx = Instantiate(objectToSpawn, firepoint.transform.position, Quaternion.identity);
            }
            timeToFire = Time.time + (1 / fireRate);
        }
    }
}
