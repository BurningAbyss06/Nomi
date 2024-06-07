using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [Header("Vida")]
    public UnityEngine.UI.Image heart1, heart2, heart3;
    public Sprite heartFull,heartHalf,hearthEmpty;

    [Header("Sake")]
    public Text sakeText;

    [Header("Transicion")]
    public UnityEngine.UI.Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFateToBlack, shouldFateFromBlack;

    [Header("Nivel Completado")]
    public GameObject LevelCompleteText;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateSakeCount();   
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
    public void UpdateHearts()
    {
        switch(PlayerHealthController.instance.currentHealth)
        {
            case 6:
                heart1.sprite =heartFull;
                heart2.sprite =heartFull;
                heart3.sprite =heartFull;
                break;
            
            case 5:
                heart1.sprite =heartFull;
                heart2.sprite =heartFull;
                heart3.sprite =heartHalf;
                break;

            case 4:
                heart1.sprite =heartFull;
                heart2.sprite =heartFull;
                heart3.sprite =hearthEmpty;
                break;
            
            case 3:
                heart1.sprite =heartFull;
                heart2.sprite =heartHalf;
                heart3.sprite =hearthEmpty;
                break;

            case 2:
                heart1.sprite =heartFull;
                heart2.sprite =hearthEmpty;
                heart3.sprite =hearthEmpty;
                break;

            case 1:
                heart1.sprite =heartHalf;
                heart2.sprite =hearthEmpty;
                heart3.sprite =hearthEmpty;
                break;

            case 0:
                heart1.sprite =hearthEmpty;
                heart2.sprite =hearthEmpty;
                heart3.sprite =hearthEmpty;
                break;
            default:
                heart1.sprite =hearthEmpty;
                heart2.sprite =hearthEmpty;
                heart3.sprite =hearthEmpty;
                break;
        }
    }
    public void UpdateSakeCount()
    {
       sakeText.text= LevelManager.instance.sakeCollected.ToString();
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
}
