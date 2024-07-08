using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanHit : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerHealthController.instance.TakeDamage(2);
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
