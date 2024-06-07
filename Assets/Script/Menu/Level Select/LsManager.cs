using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class LsManager : MonoBehaviour
{
    public LsPLayer player;
    private MapPoint[]allpoints;

     
    void Start()
    {
        allpoints = FindObjectsOfType<MapPoint>();

        if(PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach(MapPoint point in allpoints)
            {
                if(point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    player.transform.position =point.transform.position;
                    player.currentPoint = point;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel( )
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo(){
        LsUIManager.instance.FadeToBlack();
        yield return new WaitForSeconds((1f/LsUIManager.instance.fadeSpeed)+ .25f);
        SceneManager.LoadScene(player.currentPoint.levelName);
    }
}
