using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LsPLayer : MonoBehaviour
{
    public MapPoint currentPoint;
    public float moveSpeed =10f;
    public bool levelLoading;
    public LsManager manger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position,moveSpeed*Time.deltaTime);

            if(Vector3.Distance(transform.position, currentPoint.transform.position)< .1f)
            {
            if(Input.GetAxisRaw("Horizontal") > .5f) 
            {
                if(currentPoint.right !=null)
                {
                    SetNewPoint(currentPoint.right);
                }
            }
            if(Input.GetAxisRaw("Horizontal") < -.5f) 
            {
                if(currentPoint.left !=null)
                {
                    SetNewPoint(currentPoint.left);
                }
            }
            if(Input.GetAxisRaw("Vertical") > .5f) 
            {
                if(currentPoint.up !=null)
                {
                    SetNewPoint(currentPoint.up);
                }
            }
            if(Input.GetAxisRaw("Vertical") < -.5f) 
            {
                if(currentPoint.down !=null)
                {
                    SetNewPoint(currentPoint.down);
                }
            } 
            if(currentPoint.isLevel&& currentPoint.levelName!=""&&!currentPoint.isLock)
            {
                LsUIManager.instance.ShowLevelInfo(currentPoint);
                if(Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;
                    manger.LoadLevel();
                }
            }         
        }
    }

    public void SetNewPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
        LsUIManager.instance.HideLevelInfo();

    }
}
