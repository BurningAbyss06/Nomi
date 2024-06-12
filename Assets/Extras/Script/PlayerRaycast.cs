using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] LayerMask Ground;
    private float tiempoAire;
    public float velocidad;
    public float velocidadSalto;


    void Start()
    {
        rb= gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity= new Vector3(Input.GetAxisRaw("Horizontal")*velocidad,rb.velocity.y,0); 

        RaycastHit2D raycastground= Physics2D.Raycast(transform.position,Vector2.down,1.5f,Ground);

        Debug.DrawRay(transform.position,Vector2.down,Color.white);

        if(raycastground==true)
        {
            tiempoAire=0;
        }else
        {
            tiempoAire+=Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(raycastground==true)
            {
                rb.velocity= new Vector2(rb.velocity.x,velocidadSalto);

            }
            else
            {
                if (tiempoAire <0.25f)
                {
                    rb.velocity= new Vector2(rb.velocity.x,velocidadSalto);

                }
            }


        }
    }
}
