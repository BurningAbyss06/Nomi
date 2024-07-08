using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanRange : MonoBehaviour
{
    public Animator ani;
    public Swordsman_behavior enemies;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            enemies.attack = true;
            GetComponent<BoxCollider2D>().enabled =false;
        }
    }
    
}
