using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Swordsman_behavior : MonoBehaviour
{
    [Header("Movimiento")]
    public int rutina;
    public float cronometro;
    private Animator ani;
    public int dir;
    public float speed_walk;
    public float speed_run; 

    [Header("Atacck")]
    public GameObject player;
    public bool attack;
    public float range_vision;
    public float range_attack;
    public GameObject range;
    public GameObject hit;


    private void Start()
    {
        ani= GetComponent<Animator>();
        player= GameObject.Find("Raven");
    }

    private void Update()
    {
        Comportamiento();
    }


    public void Comportamiento()
    {
        if(Mathf.Abs(transform.position.x - player.transform.position.x) > range_vision && !attack)
        {
            ani.SetBool("run",false);
            cronometro += 1* Time.deltaTime;
            if(cronometro >= 3)
            {
                rutina =Random.Range(0,2);
                cronometro =0;
            }

            switch(rutina)
            {
                case 0:
                    ani.SetBool("walk",false);
                    break;
                case 1:
                    dir= Random.Range(0,2);
                    rutina++;
                    break;
                case 2:
                    switch(dir)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0,0,0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                        case 1:
                            transform.rotation = Quaternion.Euler(0,180,0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                    }
                    ani.SetBool("walk",true);
                    break;
            }
        }else
        {
            if(Mathf.Abs(transform.position.x - player.transform.position.x) > range_vision && !attack)
            {
                if(transform.position.x < player.transform.position.x)
                {
                    ani.SetBool("walk",false);
                    ani.SetBool("run",true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0,0,0);
                    ani.SetBool("attack",false);
                }else
                {
                    ani.SetBool("walk",false);
                    ani.SetBool("run",true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0,180,0);
                    ani.SetBool("attack",false); 
                }   
            }else
            {
                if(attack)
                {
                    if(transform.position.x < player.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0,0,0);

                    }else
                    {
                        transform.rotation = Quaternion.Euler(0,180,0);
                    }
                    ani.SetBool("walk",false);
                    ani.SetBool("run",false);
                }
            }
        }   
    }

    public void Final_ani ()
    {
        ani.SetBool("attack",false);
        attack =false;
        range.GetComponent<BoxCollider2D>().enabled =true;
    }
    public void ColliderWaaponTrue()
    {
        hit.GetComponent<BoxCollider2D>().enabled=true;

    }
        public void ColliderWaaponFalse()
    {
        hit.GetComponent<BoxCollider2D>().enabled=false;
        
    }
}
