using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{
    public float speed, jumpForce;
    public Transform groundCheck,cellCheck;
    public LayerMask ground;
    public int cherry, gem;
    public Text cherryNum, gemNum;
    public AudioSource jumpAudio,hurtAudio,collectionAudio;
    private Collider2D Discoll; 
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    private bool jumpPressed, crouchPressed;
    private int jumpCount;
    private bool isHurt, isCrouch, isJump, isGround, isCell;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        Discoll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update(){
        if (Input.GetButtonDown("Jump") && jumpCount>0){
            jumpPressed = true;
        }
        if (Input.GetButton("Crouch") && isGround){
            crouchPressed = true;
        }
        if (Input.GetButtonUp("Crouch")){
            crouchPressed = false;
        }
    }
    private void FixedUpdate(){
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        isCell = Physics2D.OverlapCircle(cellCheck.position, 0.1f, ground);
        if (!isHurt) GroundMovement(); 
        Jump();
        Crouch();
        switchAnim();
    }
    void GroundMovement(){
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        if (horizontalMove!=0){
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }
    void Jump(){
        if (isGround){
            jumpCount = 2;
            isJump = false;
        }
        if(jumpPressed && isGround){
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpAudio.Play();
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount>0){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpAudio.Play();
            jumpCount--;
            jumpPressed = false;
        }
    }
    void Crouch(){
        if (crouchPressed && isGround){
            isCrouch = true;
            crouchPressed = false;
        }
        else if (!crouchPressed && !isCell){
            isCrouch = false;
        }
    }
    void switchAnim(){
        anim.SetFloat("Running", Mathf.Abs(rb.velocity.x));
        if (isCrouch && !isJump){
            anim.SetBool("Crouching", true);
            Discoll.enabled = false;
        }
        else{
            anim.SetBool("Crouching", false);
            Discoll.enabled = true;
        }
        if (isHurt){
            anim.SetBool("Hurt", true);
            if (Mathf.Abs(rb.velocity.x) < 0.1f){
                isHurt = false;
                anim.SetBool("Hurt", false);
                anim.SetBool("Idle", true);
            }
        }
        if (isGround){
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", true);
        }
        else if (rb.velocity.y>0){
            anim.SetBool("Jumping", true);
        }
        else {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Cherry"){
            collectionAudio.Play();
            collision.GetComponent<Animator>().Play("IsGot");
        }
        if (collision.tag == "Gem"){
            collectionAudio.Play();
            collision.GetComponent<Animator>().Play("IsGot");
        }
        if (collision.tag=="DyingLine"){
            
        }
    }
    public void CherryCount(){
        cherry++;
        cherryNum.text = cherry.ToString();
    }
    public void GemCount(){
        gem++;
        gemNum.text = gem.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag=="Enemy"){
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (anim.GetBool("Falling")){
                enemy.JumpOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (transform.position.x < collision.gameObject.transform.position.x){
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                hurtAudio.Play();
                isHurt = true;
            }
            else if (transform.position.x > collision.gameObject.transform.position.x){
                rb.velocity = new Vector2(speed, rb.velocity.y);
                hurtAudio.Play();
                isHurt = true;
            }
        }
    }
}
