using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float WaitToRespawn;

    public int sakeCollected;


    public string levelToLoad;

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

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }
    public IEnumerator EndLevelCo()
    {   
        PlayerController.instance.stopInput = true;
        CamaraController.instance.stopFollow = true;
        UIController.instance.LevelCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f/UIController.instance.fadeSpeed)+.25f);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked",1);
        PlayerPrefs.SetString("CurrentLevel",SceneManager.GetActiveScene().name);

        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_sakes"))
        {
            if(sakeCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_sakes",sakeCollected))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_sakes",sakeCollected);
            }
        }else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_sakes",sakeCollected);
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
