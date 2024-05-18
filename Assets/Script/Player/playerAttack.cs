using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerController playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField]  private Transform bulletPoint;
    [SerializeField]  private GameObject[] bullets; 


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerController>();
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

        anim.SetTrigger("attack");
        cooldownTimer = 0;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; 
        // Calcula la dirección del disparo
        Vector2 shootDirection = (mousePos - bulletPoint.position).normalized;
        
        //pool bullets
        GameObject bullet = findBullet();

        bullet.transform.position = bulletPoint.position;
        bullet.GetComponent<proyectile>().SetDirection(Mathf.Sign(shootDirection.x));


    }
    private GameObject findBullet(){
     for (int i = 0; i < bullets.Length; i++)
     {
        if (!bullets[i].activeInHierarchy) return bullets[i] ;     
     }
        return bullets[1];
    }

}

