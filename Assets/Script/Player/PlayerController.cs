using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Componentes")]
    public Rigidbody2D rb;
    [Header("Animator")]
    private Animator anim;
    private SpriteRenderer pr;

    [Header("Ground Check")]
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask WhatIsGround;

    void Start()
    {
        anim=GetComponent<Animator>();
        pr=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"),rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, WhatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce );

            }else
            {
                if(canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce );
                    canDoubleJump = false;
                }
            }
        }

        if(rb.velocity.x < 0)
        {
            pr.flipX=true;
        }else if(rb.velocity.x>0)
        {
            pr.flipX=false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("IsGrounded",isGrounded);
        anim.SetBool("DoubleJump",!canDoubleJump);

    }
}
