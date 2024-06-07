using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    [SerializeField] private Animator anim;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft = false;


    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    public void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
             moveInDirection(-1);
            else
            {
                //change direction
                directionChange();
            }
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
            moveInDirection(1);
            else
            {
                //change direction
                directionChange();
            }
        }
    }

    private void directionChange()
    {

        idleTimer += Time.deltaTime;
        anim.SetBool("moving", false);

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }


    }

    public void Awake()
    {
        initScale = enemy.localScale;
    }

    private void moveInDirection(int _direction)
    {

        idleTimer = 0;

        anim.SetBool("moving", true);

        //hacer que el enemigo mire en la direccion correcta
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //que se mueva en esa direccion 
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
