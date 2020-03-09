using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : Enemy{
    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed, jumpForce;
    public Transform leftPoint,rightPoint;
    public LayerMask ground;
    private float leftx, rightx;
    private bool faceLeft = true;
    protected override void Start(){
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        leftx = leftPoint.position.x;
        rightx = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }
    void Update(){
        swichAnim();
    }
    void Movement(){
        if (faceLeft){
            if (coll.IsTouchingLayers(ground)){
                rb.velocity = new Vector2(-speed, jumpForce);
            }
            if (transform.position.x<leftx){
                rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
                faceLeft = false;
            }
        }
        else {
            if (coll.IsTouchingLayers(ground)){
                rb.velocity = new Vector2(speed, jumpForce);
            }
            if (transform.position.x > rightx){
                rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                faceLeft = true;
            }
        }
    }
    void swichAnim(){
        if (coll.IsTouchingLayers(ground)){
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", true);
        }
        else if (rb.velocity.y>0){
            anim.SetBool("Jumping", true);
        }
        else {
            anim.SetBool("Falling", true);
            anim.SetBool("Jumping", false);
        }
    }
}
