using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float WaitToRespawn;

    public int sakeCollected;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    //Corutina encargada de hacer que el jugdar reaparesca una vez muerto
    IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(WaitToRespawn- (1f/UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f/UIController.instance.fadeSpeed)+.2f);
        UIController.instance.FadeFromBlack();


        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth=PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHearts();
    }
}
