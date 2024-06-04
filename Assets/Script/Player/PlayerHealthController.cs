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
    public void TakeDamage()
    {
        if(invincibleCounter <= 0)
        {
            currentHealth --;
            PlayerController.instance.anim.SetTrigger("Hurt");

            if(currentHealth <= 0)
            {
                currentHealth=0;
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
}
