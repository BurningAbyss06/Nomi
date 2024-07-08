using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporal_Plataform : MonoBehaviour
{
    [SerializeField] private float time;
    private Rigidbody2D rb;
    //private Animator anim;
    public float wait_time;
    public Vector3 posini;
    private SpriteRenderer sr;
    private Collider2D col;
    
    void Start()
    {
        posini=transform.position;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Down(other));
        }
        if(other.gameObject.layer== LayerMask.NameToLayer("Ground"))
        {
            Change_State(false);
            StartCoroutine(Respawn());
        }
    }

    private  void Change_State(bool state)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        sr.enabled=state;
        col.enabled=state;
    }
    private IEnumerator Down(Collision2D other)
    {
        yield return new WaitForSeconds(time);
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(),other.transform.GetComponent<Collider2D>());
        rb.constraints= RigidbodyConstraints2D.None;
        rb.AddForce(new Vector2(0.1f, 0)); 
    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(wait_time);
        transform.position=posini;
        Change_State(true);
    }
}
