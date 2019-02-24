using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f_Gun : MonoBehaviour {
    public Animator anim;

    public Transform firePoint;

    public GameObject bullet;

    public float fireRate = 10f;
    [HideInInspector]
    public float lastBulletTime = 0f;

    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
        lastBulletTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton ("Fire1") && Time.time > lastBulletTime) {
            if(!audio.isPlaying) {
                audio.Play();
            }
            anim.SetBool ("fire", true);
            if (bullet) {
                Instantiate (bullet, firePoint.position, Quaternion.identity);
            }
            lastBulletTime = Time.time + (1 / fireRate);
        } else if (Input.GetButtonUp ("Fire1")) {
            anim.SetBool ("fire", false);
            if(audio.isPlaying) {
                audio.Stop();
            }
        }

    }
}