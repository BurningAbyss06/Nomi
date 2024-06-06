using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect, mainMenu;
    public GameObject pauseScreaen;
    public bool isPaused;
    
    public void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            PauseUnoause();
        }
    }

    public void PauseUnoause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreaen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseScreaen.SetActive(true);
            Time.timeScale = 0f;
            
        }
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }
        public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
