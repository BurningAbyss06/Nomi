using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    [Header("Vida")]
    public int currentHealth;
    public int maxHealth;
    public float invincibility;
    private float invincibleCounter;
    private SpriteRenderer sr;
    [SerializeField] private AudioClip hurtClip,dethClip;

    public GameObject deathEffect;
    public void Awake()
    {
        instance = this;
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
    public void TakeDamage(int damage = 1)
    {
        if(invincibleCounter <= 0)
        {
            currentHealth -= damage;
            SFXController.instance.PlaySound(hurtClip);
            PlayerController.instance.anim.SetTrigger("Hurt");

            if(currentHealth <= 0)
            {
                currentHealth=0;

                SFXController.instance.PlaySound(dethClip);
                Instantiate(deathEffect,PlayerController.instance.transform.position,PlayerController.instance.transform.rotation);
                LevelManager.instance.RespawnPlayer();
            }else
            {
                invincibleCounter=invincibility;
                sr.color =new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                PlayerController.instance.KnockBack();
            }
            UIController.instance.UpdateHearts();
        }
       
    }

        public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        } 
        UIController.instance.UpdateHearts();   
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Plataforma")
        {
            transform.parent =other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag=="Plataforma")
        {
            transform.parent =null;
        }
    }
}
