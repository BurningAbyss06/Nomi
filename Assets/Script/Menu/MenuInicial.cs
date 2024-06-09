using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class MenuInicial : MonoBehaviour
{
    public string startScene, continueScene;

    public GameObject continueButton;

    public void Start()
    {
        if(PlayerPrefs.HasKey(startScene + "_unlocked"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void Jugar()
    {   
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    public void Salir()
    {
        Debug.Log("Salir");


        Application.Quit();
    }
}
