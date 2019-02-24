using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f_Bullet : MonoBehaviour
{

    public float speed = 10f;

    public GameObject muzzleFlash;
    public GameObject hitImpact;

    // Start is called before the first frame update
    void Start()
    {
        if(muzzleFlash)
            Instantiate (muzzleFlash, gameObject.transform.position, muzzleFlash.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    // void OnCollisionEnter(Collision other) {

    //     ContactPoint contact = other.contacts[0];
    //     Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    //     Vector3 pos = contact.point;

    //     if(hitImpact) {
    //         Instantiate (hitImpact, pos, rot);
    //     }

        

    //     Destroy(this.gameObject);
    // }

    void OnTriggerEnter(Collider other) {

        if(hitImpact) {
            Instantiate (hitImpact, transform.position, Quaternion.identity);
        }

        if(other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyAI>().KillMe();
        }
        Destroy(this.gameObject);
    }
}
