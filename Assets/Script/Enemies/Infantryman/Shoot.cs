using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    public Transform shootController;
   public float distancia;
   public LayerMask player;
   public bool playerInRange;
   public GameObject bala;
   public float cooldown;
   public float lastshoot;
   public float tiempoEspera;
   private Animator anim;
   [SerializeField] private AudioClip shootClip;

   private void Start()
   {
        anim=GetComponent<Animator>();
   }

   private void Update()
   {
    
        playerInRange= Physics2D.Raycast(shootController.position,transform.right,distancia,player);
        if(playerInRange)
        {
            if(Time.time >cooldown + lastshoot)
            {
                lastshoot= Time.time;
                anim.SetTrigger("Shoot");
                SFXController.instance.PlaySound(shootClip);
                Invoke(nameof(Disparo),tiempoEspera);
            }
        }
   }

    private void Disparo()
    {
        Instantiate(bala,shootController.position,shootController.rotation);
    }
  
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawLine(shootController.position,shootController.position +transform.right *distancia);
    }
}
