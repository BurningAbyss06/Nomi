using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static  SFXController instance;
    private AudioSource au;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
        au = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        au.PlayOneShot(clip);
    }
}
