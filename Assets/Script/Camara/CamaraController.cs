using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public static CamaraController instance;
    public Transform target;
    public Transform fb,mb;
    private Vector2 lastPos;
    public float minHight, maxHight;
    public bool stopFollow;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        if(!stopFollow){
            transform.position = new Vector3(target.position.x,Mathf.Clamp(target.position.y,minHight, maxHight), transform.position.z);
            Vector2 amountToMove= new Vector2(transform.position.x-lastPos.x,transform.position.y-lastPos.y);
            fb.transform.position = fb.position + new Vector3(amountToMove.x,amountToMove.y,0f);
            mb.transform.position += new Vector3(amountToMove.x,amountToMove.y,0f)*.7f;   
            lastPos = transform.position;
        }


    }
}
