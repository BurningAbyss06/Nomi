using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class MenuInicial : MonoBehaviour
{
    public string startScene, continueScene, controlesScene;

    public GameObject continueButton;
    [SerializeField] private AudioClip selectClip, pressClip;

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
        SFXController.instance.PlaySound(selectClip);
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
    }

    public void ContinueGame()
    {
        SFXController.instance.PlaySound(pressClip);
        SceneManager.LoadScene(continueScene);
    }
    public void Controles()
    {
        SFXController.instance.PlaySound(pressClip);
        SceneManager.LoadScene(controlesScene);
    }

    public void Salir()
    {
        Debug.Log("Salir");


        Application.Quit();
    }
}
