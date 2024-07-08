using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{
    public string continuegame;

    public void Jugar()
    {   
        
        SceneManager.LoadScene(continuegame);
    }
}
