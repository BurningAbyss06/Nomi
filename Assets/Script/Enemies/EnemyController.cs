using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    public float speed;
    public Transform leftpoint, rightpoint;
    private bool movingRight;
    private Rigidbody2D rb;
    public SpriteRenderer sp;
    private Animator anim;

    public float moveTime, waitTime;
    private float moveCount, waitCount;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();

        leftpoint.parent=null;
        rightpoint.parent=null;

        movingRight=false;
        moveCount=moveTime;
    }

    void Update()
    {
        if(moveCount>0)
        {
            moveCount-=Time.deltaTime;  
            if(movingRight)
            {
                rb.velocity=new Vector2(speed,rb.velocity.y);
                sp.flipX=true;

                if(transform.position.x > rightpoint.position.x)
                {
                movingRight=false;
                }
            }else
            {
                rb.velocity=new Vector2(-speed,rb.velocity.y);
                sp.flipX=false;
                if(transform.position.x < leftpoint.position.x)
                {
                    movingRight=true;
                }
            }
            if(moveCount<=0)
            {
                waitCount= Random.Range(waitTime *.75f,waitTime * 1.25f);
            }
            anim.SetBool("isMoving",true);
        }else if(waitCount >0)
        {
            waitCount -=Time.deltaTime;
            rb.velocity=new Vector2(0f,rb.velocity.y);

            if(waitCount<=0)
            {
                moveCount= Random.Range(moveTime *.75f,waitTime * 1.25f);
            }
            anim.SetBool("isMoving",false);

        }
    }
}
