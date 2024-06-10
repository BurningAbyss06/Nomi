using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantrymanHealthController : MonoBehaviour
{
    public static InfantrymanHealthController instance;

    [Header("Vida")]
    public int currentHealth;
    public int maxHealth;
    public float invincibility;
    private float invincibleCounter;
    private SpriteRenderer sr;
    private Animator anim;
    public bool isDied = false;

    public void Awake()
    {
        instance = this;
        anim= GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        sr=GetComponent<SpriteRenderer>();
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
            anim.SetTrigger("hurt");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDied = true;
                anim.SetTrigger("die");
                Destroy(gameObject);
            }
            else
            {
                invincibleCounter = invincibility;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

            }   
        }
    }
}
