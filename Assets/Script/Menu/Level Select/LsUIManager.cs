using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LsUIManager : MonoBehaviour
{
    public static LsUIManager instance;
    
    [Header("Transicion")]
    public UnityEngine.UI.Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFateToBlack, shouldFateFromBlack; 

    [Header("Nombre de Los Niveles")]
    public GameObject levelInfoPanel;
    public Text levelName;

    [Header("Info Panel")]
    public Text sakeFound, sakeTarget;
    void Awake()
    {
      instance =this;  
    }
    void Start()
    {   
        FadeFromBlack();
    }

    void Update()
    {
        if (shouldFateToBlack)
        {
            fadeScreen.color= new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,Mathf.MoveTowards(fadeScreen.color.a,1f,fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a==1f)
            {
                shouldFateToBlack = false;
            }
        }

        if (shouldFateFromBlack)
        {
            fadeScreen.color= new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,Mathf.MoveTowards(fadeScreen.color.a,0f,fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a==0f)
            {
                shouldFateFromBlack = false;
            }
        }        
    }

    public void FadeToBlack()
    {
        shouldFateToBlack = true;
        shouldFateFromBlack = false;
    }
    public void FadeFromBlack()
    {
        shouldFateToBlack = false;
        shouldFateFromBlack = true;
    }
    public void ShowLevelInfo(MapPoint levelInfo)
    {
        levelName.text= levelInfo.levelName;
        sakeFound.text= "Sake Found: " + levelInfo.sakeCollected;
        sakeTarget.text= "Total: " + levelInfo.totalSake;
        levelInfoPanel.SetActive(true);

    }
    public void HideLevelInfo()
    {
        levelInfoPanel.SetActive(false);
    }
}
