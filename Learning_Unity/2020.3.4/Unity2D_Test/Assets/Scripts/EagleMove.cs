using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMove : Enemy{
    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed;
    public Transform topPoint, bottomPoint;
    private float topy, bottomy;
    private bool isUp = true;
    protected override void Start(){
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        topy = topPoint.position.y;
        bottomy = bottomPoint.position.y;
        Destroy(topPoint.gameObject);
        Destroy(bottomPoint.gameObject);
    }
    void Update(){
        Movement();
    }
    void Movement(){
        if (isUp){
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (rb.position.y>topy) isUp = false;
        }
        else {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (rb.position.y < bottomy) isUp = true;
        }
    }
}
