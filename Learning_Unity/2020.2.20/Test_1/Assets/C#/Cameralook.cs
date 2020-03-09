using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameralook : MonoBehaviour
{
    public float mousespeed;
    public Transform player;
    private float xmove;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x, y;
        x = Input.GetAxis("Mouse X") * mousespeed * Time.deltaTime;
        y = Input.GetAxis("Mouse Y") * mousespeed * Time.deltaTime;
        xmove = xmove - y;
        xmove = Mathf.Clamp(xmove, -60, 60);
        this.transform.localRotation = Quaternion.Euler(xmove, 0, 0);
        player.Rotate(Vector3.up * x);

    }
}
