using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float speed;
    public float jumpspeed;
    public float g;
    public float dashspeed;
    public float dashspeeddown;
    public CharacterController playercontroller;
    Vector3 move;

    // Update is called once per frame
    void Update()
    {
        float x = 0, z = 0;
        if (playercontroller.isGrounded){
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            move = transform.right * x + transform.forward * z;
            move = move * speed;
            if (Input.GetAxis("Jump") == 1)
            {
                move.y = jumpspeed;
            }
        }
        move.y = move.y - g*Time.deltaTime;
        playercontroller.Move(move*Time.deltaTime);
    }
}
