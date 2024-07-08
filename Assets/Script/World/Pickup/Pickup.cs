using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool IsSake, isHeal;
    private bool isCollected;
    public GameObject sakeE;
    [SerializeField] private AudioClip sakeClip;
    [SerializeField] private AudioClip healClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&& !isCollected)
        {
            if(IsSake)
            {
                LevelManager.instance.sakeCollected++; 
                UIController.instance.UpdateSakeCount();    
                Instantiate(sakeE,transform.position, transform.rotation);                 
                isCollected = true;
                SFXController.instance.PlaySound(sakeClip);
                Destroy(gameObject); 
            }
            if (isHeal)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    Instantiate(sakeE,transform.position, transform.rotation);                 
                    isCollected=true;
                    SFXController.instance.PlaySound(healClip);
                    Destroy(gameObject);
                }
            }
        }
    }
}
