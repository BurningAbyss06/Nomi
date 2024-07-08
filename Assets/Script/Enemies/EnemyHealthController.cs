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
    public bool isDied = false;

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
    public void TakeDamage()
    {
        if (isDied) return;
        
        if (invincibleCounter <= 0)
        {
            currentHealth--;
            animator.SetTrigger("hurt");


            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.SetTrigger("die");

                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                }


                if (GetComponent<MeleeEnemyController>() != null)
                {
                    GetComponent<MeleeEnemyController>().enabled = false;
                }
                 
                isDied = true;
                gameObject.SetActive(false);


            }
            else
            {
                invincibleCounter = invincibility;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

            }            
        }  
    }
}
