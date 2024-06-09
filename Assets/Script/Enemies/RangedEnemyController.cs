using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RangedEnemyController : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Ranged parameters")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] proyectiles;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    [Header("Referenced Parameters")]
    private Animator anim;
    private EnemyPatrol enemyPatrol;
    private SpriteRenderer pr; 

    void Start()
    {
        
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        pr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //attack
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
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

    private void rangedAttack()
    {
        if (PlayerInSight())
        {

            GameObject bullet = findBullet();
            bullet.transform.position = firepoint.position;

            float direction = (bullet.transform.localScale.x > 0) ? 1 : -1;

            if (direction < 0)
            {
                bullet.transform.position = new Vector3(bullet.transform.position.x - 5, transform.position.y, transform.position.z);
                pr.flipX = true;
            }
            else
            {
                pr.flipX = false;
            }
;
            bullet.GetComponent<EnemyProyectile>().SetDirectionAndDamage(Mathf.Sign(transform.localScale.x), damage);


        }

    }

    private GameObject findBullet()
    {
        for (int i = 0; i < proyectiles.Length; i++)
        {
            if (!proyectiles[i].activeSelf) return proyectiles[i];
        }
        return proyectiles[1];
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
