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
    private CapsuleCollider2D capsule;
    public float IzoffsetX;
    public float IzoffsetY;
    public float IzsizeX;
    public float IzsizeY;
    public float DeroffsetX;
    public float DeroffsetY;
    public float DersizeX;
    public float DersizeY;

    [Header("Ground Check")]
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask WhatIsGround;

    void Start()
    {
        anim=GetComponent<Animator>();
        pr=GetComponent<SpriteRenderer>();
        capsule=GetComponent<CapsuleCollider2D>();
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
            capsule.offset=new Vector2(IzoffsetX,IzoffsetY);
            capsule.size=new Vector2 (IzsizeX,IzsizeY);
        }else if(rb.velocity.x>0)
        {
            pr.flipX=false;
            capsule.offset=new Vector2(DeroffsetX,DeroffsetY);
            capsule.size=new Vector2 (DersizeX,DersizeY);
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("IsGrounded",isGrounded);
        anim.SetBool("DoubleJump",!canDoubleJump);

    }

    public bool canAttack()
    {
        return Input.GetAxis("Horizontal") == 0 && isGrounded;
    }
}
