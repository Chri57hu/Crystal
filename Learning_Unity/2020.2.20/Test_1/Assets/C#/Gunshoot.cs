using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshoot : MonoBehaviour
{
    public GameObject bullet;
    public int shootime;
    public int shootlimit;
    void Update()
    {
        if (shootime <= 0){
            if (Input.GetAxis("Fire1") == 1){
                GameObject Bullet = GameObject.Instantiate(bullet, transform.position, transform.rotation);
                shootime = shootlimit;
            }
        }
        else shootime = shootime - 1;
    }
}
