using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class CambioEscena : MonoBehaviour
{
    private void Update()
    {
       StartCoroutine(hola());
    }

    IEnumerator hola()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level 1-0",LoadSceneMode.Single);

    }
}
