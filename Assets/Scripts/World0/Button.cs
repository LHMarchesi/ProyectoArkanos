using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Button : MonoBehaviour
{
   
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool buttonPress;
    [SerializeField] private Sprite spriteDefault;
    [SerializeField] private Sprite spritePress;

    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.sprite = spriteDefault;
        buttonPress = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !IsButtonPress())
        {
            spriteRenderer.sprite = spritePress;
            buttonPress = true;
        }


    }

    public bool IsButtonPress()
    {
        return buttonPress;
    }
}
