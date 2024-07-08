using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantryman_Behavior : MonoBehaviour
{
    [Header("Movimiento")]
    public int rutina;
    public float cronometro;
    private Animator ani;
    public int dir;
    public float speed_walk;

    void Start()
    {
        ani= GetComponent<Animator>();
    }

    void Update()
    {
        Comportamiento();
    }

    public void Comportamiento()
    {
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
    }
}
