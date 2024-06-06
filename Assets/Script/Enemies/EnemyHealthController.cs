using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public static EnemyHealthController instance;

    [Header("Vida")]
    public int currentHealth;
    public int maxHealth;
    public float invincibility;
    private float invincibleCounter;
    private SpriteRenderer sr;
    private Animator animator;

    public void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(invincibleCounter>0)
        {
            invincibleCounter -= Time.deltaTime;
        }

        if(invincibleCounter <=0)
        {
            sr.color =new Color(sr.color.r, sr.color.g, sr.color.b,1f);
        }
    }
    //funcion encargada de controlar cuanta vida le queda al jugador y llamar a la funcion para que reaparesca si muere 
    public void TakeDamage()
    {
        if(invincibleCounter <= 0)
        {
            currentHealth --;
            animator.SetTrigger("hurt");

            if(currentHealth <= 0)
            {
                currentHealth=0;
                animator.SetTrigger("die");

                //Instantiate(deathEffect,PlayerController.instance.transform.position,PlayerController.instance.transform.rotation);
                //LevelManager.instance.RespawnPlayer();
                
            }else
            {
                invincibleCounter=invincibility;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                //PlayerController.instance.KnockBack();
            }
            //UIController.instance.UpdateHearts();
        }
       
    }

}
