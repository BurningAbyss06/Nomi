using System;
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
    public float doublejumpForce;

    [Header("Componentes")]
    public Rigidbody2D rb;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer pr;

    [Header("Ground Check")]
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask WhatIsGround;

    [Header("KnockBack")]
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    [Header("Escaleras")]
    [SerializeField] private float velocidadEscalar;
    private CapsuleCollider2D capsule;
    private float gravityinicial;
    private bool isclimb;
    
    [Header("Fin Nivel")]
    public bool stopInput;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim=GetComponent<Animator>();
        pr=GetComponent<SpriteRenderer>();
        capsule=GetComponent<CapsuleCollider2D>();
        gravityinicial=rb.gravityScale;
    }

    void Update()
    {
        if((!PauseMenu.instance.isPaused)&&(!stopInput)){
        if(knockBackCounter <= 0)
        {
            rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"),rb.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, WhatIsGround);
            Climb();

            if(Mathf.Abs(rb.velocity.y) > Mathf.Epsilon)
            {
                anim.SetFloat("VelocityY", Mathf.Sign(rb.velocity.y));
            }else
            {
                anim.SetFloat("VelocityY", 0f);
            }

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
                        rb.velocity = new Vector2(rb.velocity.x, doublejumpForce );
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
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("IsGrounded",isGrounded);
        anim.SetBool("DoubleJump",!canDoubleJump);

    }

    public void Climb()
    {
        if((Input.GetAxisRaw("Vertical")!=0||isclimb)&&capsule.IsTouchingLayers(LayerMask.GetMask("Escalera")))
        {
            Vector2 velocidadsubida= new Vector2(rb.velocity.x,Input.GetAxisRaw("Vertical")*velocidadEscalar);
            rb.velocity=velocidadsubida;
            rb.gravityScale=0f;
            isclimb=true;
        }else
        {
            rb.gravityScale=gravityinicial;
            isclimb=false;
        }
        if(isGrounded)
        {
            isclimb=false;
        }
        anim.SetBool("IsClimbing", isclimb);
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
