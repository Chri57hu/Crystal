using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooted : MonoBehaviour
{
    public GameObject shell;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<hp>().hpdecrease(25);
        }
        GameObject shells = GameObject.Instantiate(shell, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
