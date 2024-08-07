using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class proyectile : MonoBehaviour
{

    [SerializeField] private float speed;
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
           // gameObject.SetActive(false);
            return;
        }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        life_time += Time.deltaTime;
        if (life_time > 5) gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
 

       if (collision.name == "Player"){
            return;
       }
       if (collision.name.Contains("Sake")){
            return;
       }
        if (collision.name.Contains("Ladder"))
        {
            return;
        }

        if (collision.name.Contains("Cthulu") ||
            collision.name.Contains("Android")) 
        {
            if (collision.GetComponent<EnemyHealthController>().isDied)
            {
                return;
            }
            else
            {
                collision.GetComponent<EnemyHealthController>().TakeDamage();
            }
        }
        

        if(collision.name.Contains("Enemy_Alien_Dino")||collision.name.Contains("Infantryman") || collision.name.Contains("Swordsman"))
        {
            if(collision.GetComponent<DinoHealthController>())
            {
                if (collision.GetComponent<DinoHealthController>().isDied)
                {
                    return;
                }
                else
                {
                    collision.GetComponent<DinoHealthController>().TakeDamage();
                }
            }
            if(collision.GetComponent<InfantrymanHealthController>())
            {
                if (collision.GetComponent<InfantrymanHealthController>().isDied)
                {
                    return;
                }
                else
                {
                    collision.GetComponent<InfantrymanHealthController>().TakeDamage();
                }
            }
            if (collision.GetComponent<SwordsmanHealthController>())
            {
                if (collision.GetComponent<SwordsmanHealthController>().isDied)
                {
                    return;
                }
                else
                {
                    collision.GetComponent<SwordsmanHealthController>().TakeDamage();
                }
            }
        }

        anim.SetTrigger("explode");
        hit = true;
        boxCollider.enabled = false;
    }

    public void SetDirection(float _direction)
    {

        life_time = 0;

        direction = _direction;
        gameObject.SetActive(true);
        hit = false;

        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction){
            localScaleX = -1*localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactive(){
        gameObject.SetActive(false);
    }

}
