using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    //public int damage;
    void Update()
    {
        transform.Translate(Time.deltaTime *speed * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            PlayerHealthController.instance.TakeDamage();
            Destroy(gameObject);
            
        }
        if(other.tag=="Untagged")
        {
            Destroy(gameObject,Time.deltaTime + 3f);
 
        }
    }
}
