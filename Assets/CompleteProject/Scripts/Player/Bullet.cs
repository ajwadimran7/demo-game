using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float fireRate;

    public GameObject MuzzlePrefab;
    public GameObject HitPrefab;

    void Start()
    {
        if(MuzzlePrefab) {
            GameObject muzzle = Instantiate(MuzzlePrefab, transform.position, MuzzlePrefab.transform.rotation);
        }
    }
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        speed = 0f;

        ContactPoint contact = other.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(HitPrefab) {
            GameObject hitvfx = Instantiate(HitPrefab, pos, rot);
        }
        Destroy(this.gameObject);
    }
}
