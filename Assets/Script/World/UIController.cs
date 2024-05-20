using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public UnityEngine.UI.Image heart1, heart2, heart3;

    public Sprite heartFull,heartHalf,hearthEmpty;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
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
}
