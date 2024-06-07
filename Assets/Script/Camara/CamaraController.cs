using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public static CamaraController instance;
    public Transform target;
    public Transform fb,mb;
    private float lastxPos;
    public float minHight, maxHight;
    public bool stopFollow;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lastxPos = transform.position.x;
    }

    void Update()
    {
        if(!stopFollow){
            transform.position = new Vector3(target.position.x,Mathf.Clamp(target.position.y,minHight, maxHight), transform.position.z);
            float amountToMoveX= transform.position.x - lastxPos;
            fb.transform.position = fb.position + new Vector3(amountToMoveX,0f,0f);
            mb.transform.position += new Vector3(amountToMoveX * .5f,0f,0f);   
            lastxPos = transform.position.x;
        }


    }
}
