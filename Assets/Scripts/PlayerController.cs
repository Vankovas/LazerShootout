using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Speed vars
    public float moveSpeed;
    public float jumpForce;
    //Controls
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;
    //Ground
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    //Rigidbody
    private Rigidbody2D theRB;
    //Animator
    private Animator anim;
    //lazer
    public GameObject lazer;
    public Transform shootPoint;
    public AudioSource lazerSound;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if(Input.GetKey(left)) {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

        }else if(Input.GetKey(right)) {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(shoot)) {
            GameObject lazerClone = (GameObject)Instantiate(lazer, shootPoint.position, shootPoint.rotation);
            lazerClone.transform.localScale = transform.localScale * 4;
            anim.SetTrigger("Shoot");
            lazerSound.Play();
        }

        if (Input.GetKeyDown(jump) && isGrounded) {
            theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y + jumpForce);
        }

        if(theRB.velocity.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }else if(theRB.velocity.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
}
