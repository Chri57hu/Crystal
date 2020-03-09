using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    public int hpoint = 100;

    void Update()
    {
        if (hpoint <= 0) Destroy(gameObject);
    }
    public void hpdecrease(int x)
    {
        hpoint = hpoint - x;
    }
}
