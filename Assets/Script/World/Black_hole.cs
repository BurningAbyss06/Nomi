using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_hole : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D playerBody;
    public float intensity;
    public float influenceRange;  

    void Start()
    {
        playerBody = player.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceToPlayer <= influenceRange)
        {
            Vector2 pullForce = (transform.position - player.position).normalized / distanceToPlayer * intensity;
            playerBody.AddForce(pullForce, ForceMode2D.Force);
        }

    }
}
