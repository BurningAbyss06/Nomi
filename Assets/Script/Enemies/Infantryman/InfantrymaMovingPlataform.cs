using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantrymaMovingPlataform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform controllerGraund;
    [SerializeField] private float dis;
    [SerializeField] private bool movDer;
    private Rigidbody2D rb;
    private Animator ani;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoground = Physics2D.Raycast(controllerGraund.position, Vector2.down, dis);

        rb.velocity = new Vector2(speed, rb.velocity.y);
        ani.SetBool("walk",true);
        if(infoground==false)
        {
            Girar();
        }
    }

    private void Girar ()
    {
        movDer =! movDer;
        transform.eulerAngles= new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color= Color.green;
        Gizmos.DrawLine(controllerGraund.transform.position, controllerGraund.transform.position + Vector3.down * dis);
    }
}
