using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Componentes")]
    public Rigidbody2D rb;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer pr;
    private CapsuleCollider2D capsule;

    [Header("Ground Check")]
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask WhatIsGround;

    [Header("KnockBack")]
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim=GetComponent<Animator>();
        pr=GetComponent<SpriteRenderer>();
        capsule=GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if(knockBackCounter <= 0)
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
        }else
        {
            knockBackCounter -=Time.deltaTime;
            if(!pr.flipX)
            {
                rb.velocity=new Vector2(-knockBackForce,rb.velocity.y);
            }else
            {
                rb.velocity=new Vector2(knockBackForce,rb.velocity.y);                
            }
        } 
       

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("IsGrounded",isGrounded);
        anim.SetBool("DoubleJump",!canDoubleJump);

    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        rb.velocity = new Vector2(0f, knockBackForce);
    }

    public bool canAttack()
    {
        return Input.GetAxis("Horizontal") == 0 && isGrounded;
    }
}
