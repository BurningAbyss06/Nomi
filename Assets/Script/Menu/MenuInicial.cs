using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Corrected the typo

public class MenuInicial : MonoBehaviour
{
    // This method is called when the player chooses to start the game.
    public void Jugar()
    {
        // Loads the next scene in the build order.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This method is called when the player chooses to exit the game.
    public void Salir()
    {
        // Logs a message to the console to confirm the exit command has been called.
        Debug.Log("Salir");

        // Quits the application. Note that this will only work in a built application,
        // not in the Unity editor. To test quitting in the editor, you might use
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
