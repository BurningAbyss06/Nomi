using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth;
    public int maxHealth;

    public float invincibility;
    private float invincibleCounter;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter>0)
        {
            invincibleCounter -= Time.deltaTime;
        }
    }
    public void TakeDamage()
    {
        if(invincibleCounter <= 0)
        {
            currentHealth --;

            if(currentHealth <= 0)
            {
                currentHealth=0;
                gameObject.SetActive(false);
            }else
            {
                invincibleCounter=invincibility;
            }
            UIController.instance.UpdateHearts();
        }
       
    }
}
