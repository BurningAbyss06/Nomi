using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    public Checkpoint[] checkpoints;

    public Vector3 spawnPoint;
    void Awake()
    {
        instance = this;
    }

    // Rellena el array de checkpoints y pone el primer punto de respawn en la posicion inicial del player
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint=PlayerController.instance.transform.position;
    }

    //desactiva todo los checkpoints menos el que el jugador acaba de tocar 
    public void DesactivateCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoints();
        }
    }

    //setea el spawn point en la posicion del checkpoint tocado 
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
