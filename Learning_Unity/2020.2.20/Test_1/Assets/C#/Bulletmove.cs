using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    public float force;
    public float time;
    public Rigidbody rig;
    void Start()
    {
        Destroy(gameObject, time);
        rig.AddForce(this.transform.forward * force);
    }
}
