using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject objectToPanel;
    private SpriteRenderer sr;
    public Sprite panelactivate;
    private bool hasSwitched;
    public bool deactivateOnPanel; 
    [SerializeField] private AudioClip desactivatedClip;
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player" && !hasSwitched)
        {
            if(deactivateOnPanel)
            {
                objectToPanel.SetActive(false);
            }else
            {
                objectToPanel.SetActive(true);

            }
            sr.sprite=panelactivate;
            SFXController.instance.PlaySound(desactivatedClip);
            hasSwitched=true;
        }
    }
}
