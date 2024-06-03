using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer sp;
    public Sprite cpon,cpoff;

    //Se encarga de cambiar el sprite de el checkpoint y de llamar a la funcion que desactiva los otros checkpoints y la que guarda
    //la posicion del checkpoint en la que reaparecera el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CheckpointController.instance.DesactivateCheckpoints();
            sp.sprite = cpon;
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoints()
    {
        sp.sprite = cpoff;
    }
}
