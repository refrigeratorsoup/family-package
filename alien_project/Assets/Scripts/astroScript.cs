using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroScript : MonoBehaviour
{
    [SerializeField] private LayerMask PlatformsLayer;
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] Transform groundCheck;

    bool isGrounded = false;
    const float groundCheckRadius = 0.2f ;

    private void Awake()
    {
        //grabbing references
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //left and right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        GroundCheck();

        //jumping
        if (Input.GetKey(KeyCode.W))
        {
            if (isGrounded)
            {
                Jump();
            }
        }

        //flipping
        if (horizontalInput > 0.1f)
        {
            transform.localScale = Vector3.one;
        }
        if (horizontalInput < 0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //set animator parametres
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded);
    }

    //jumpinggg
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
    }

    //ground checkk
    void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, PlatformsLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }
}
