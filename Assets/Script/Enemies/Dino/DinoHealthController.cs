using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoHealthController : MonoBehaviour
{
    public static DinoHealthController instance;

    [Header("Vida")]
    public int currentHealth;
    public int maxHealth;
    public float invincibility;
    private float invincibleCounter;
    public SpriteRenderer sr;
    private Animator anim;
    public bool isDied = false;
    [SerializeField] private AudioClip hurtClip;

    public void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
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
            SFXController.instance.PlaySound(hurtClip);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDied = true;
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
