using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform target;
    public Transform bg;
    private float lastxPos;
    public float minHight, maxHight;
    void Start()
    {
        
    }

    void Update()
    {
        //transform.position=new Vector3(target.position.x, target.position.y, target.position.z);

        transform.position = new Vector3(target.position.x,Mathf.Clamp(target.position.y,minHight, maxHight), transform.position.z);

        float amountToMoveX= transform.position.x - lastxPos;
        bg.position= bg.position + new Vector3(amountToMoveX,0f,0f);

        lastxPos = transform.position.x;
    }
}
