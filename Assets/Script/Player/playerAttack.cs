using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerController playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField]  private Transform bulletPoint;
    [SerializeField]  private GameObject[] bullets; 
    private SpriteRenderer pr;
    [SerializeField] private AudioClip attackClip;


    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerController>();
        pr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void attack()
    {   
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; 
        // Calcula la dirección del disparo
        Vector2 shootDirection = (mousePos - bulletPoint.position).normalized;
        
        //pool bullets
        GameObject bullet = findBullet();

        bullet.transform.position = bulletPoint.position;

        if (shootDirection.x < 0){
            bullet.transform.position = new Vector3(bullet.transform.position.x - 5, transform.position.y, transform.position.z);
            pr.flipX=true;
        }else
        {
            pr.flipX=false;
        }
        
        bullet.GetComponent<proyectile>().SetDirection(Mathf.Sign(shootDirection.x));
        anim.SetTrigger("attack");
        SFXController.instance.PlaySound(attackClip);
        cooldownTimer = 0;

    }
    private GameObject findBullet(){
     for (int i = 0; i < bullets.Length; i++)
     {
        if (!bullets[i].activeInHierarchy) return bullets[i] ;     
     }
        return bullets[1];
    }

}

