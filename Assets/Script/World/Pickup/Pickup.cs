using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool IsSake;

    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&& !isCollected)
        {
            if(IsSake)
            {
                LevelManager.instance.sakeCollected++;           
                isCollected = true;
                Destroy(gameObject); 
            }
        }
    }
}
