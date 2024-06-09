using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectile : MonoBehaviour
{

    [SerializeField] private float speed;
    private int damage;
    private float direction;
    private bool hit;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float life_time;

    void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (hit)
        {
            return;
        }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);


        life_time += Time.deltaTime;
        if (life_time > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.Contains("Sake"))
        {
            return;
        }
        if (collision.name.Contains("Ladder"))
        {
            return;
        }

        if (collision.name.Contains("Cthulu") ||
            collision.name.Contains("Android"))
        {
            return;
        }

        if (collision.name == "Raven")
        {
            collision.GetComponent<PlayerHealthController>().TakeDamage(damage);
        }

        anim.SetTrigger("explode");
        hit = true;
        boxCollider.enabled = false;


    }

    public void SetDirectionAndDamage(float _direction, int _damage = 1)
    {

        life_time = 0;

        direction = _direction;
        damage = _damage;

        gameObject.SetActive(true);
        hit = false;

        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -1 * localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }

    private void Deactive()
    {
        gameObject.SetActive(false);
    }

}
