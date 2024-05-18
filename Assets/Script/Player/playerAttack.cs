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
    void Start()
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
        //pool bullets

        bullets[0].transform.position = bulletPoint.position;
        bullets[0].GetComponent<proyectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

}

