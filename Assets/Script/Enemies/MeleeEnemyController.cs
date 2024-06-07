using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private  float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private PlayerHealthController playerHealth;
    private EnemyPatrol enemyPatrol;

    void Start()
    {
        
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //attack
                anim.SetTrigger("meleeAttack");
                cooldownTimer = 0;
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    
    }

    private bool PlayerInSight()

    {
        int sign = (transform.localScale.x > 0) ? 1 : -1;
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * sign * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, 
                boxCollider.bounds.size.y,
                boxCollider.bounds.size.z 
            ),
            0,
            Vector2.left,
            0,
            playerLayer
            );

         if (hit.collider != null)
         {
            playerHealth = hit.transform.GetComponent<PlayerHealthController>();                      
         }   

        return hit.collider != null; 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        int sign = (transform.localScale.x > 0) ? 1 : -1;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right *range * sign * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range,
                boxCollider.bounds.size.y,
                boxCollider.bounds.size.z
            ));
    }

    private void DoDamageToPlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage();
        }
    }

}
