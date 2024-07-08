using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LsCamaraController : MonoBehaviour
{
    public Vector2 minPos, maxPos;

    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xPos= Mathf.Clamp(player.position.x,minPos.x,maxPos.x);
        float yPos= Mathf.Clamp(player.position.y,minPos.y,maxPos.y);
        transform.position = new Vector3(xPos,yPos,transform.position.z);
    }
}
