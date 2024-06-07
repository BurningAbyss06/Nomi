using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, down, left, right;
    public bool isLevel, isLock;
    public string levelToLoad, levelToCheck, levelName;
    public int sakeCollected,totalSake;

    public GameObject SakeBadge;

    void Start()
    {
       if(isLevel&& levelToLoad != null)
        {
            if(PlayerPrefs.HasKey(levelToLoad +"_sakes"))
            {
                sakeCollected = PlayerPrefs.GetInt(levelToLoad + "_sakes");
            }

            if((sakeCollected >= totalSake)&& totalSake !=0)
            {
                SakeBadge.SetActive(true);
            }

            isLock=true;
            if(levelToCheck != null)
            {
                if(PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked")==1)
                    {
                        isLock=false;
                    }
                }
            }
            if(levelToLoad==levelToCheck)
            {
                isLock= false;
            }
        }
    }

    void Update()
    {
        
    }
}
