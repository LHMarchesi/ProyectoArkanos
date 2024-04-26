using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Button : MonoBehaviour
{
   
    [SerializeField] public bool buttonPress;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        

        buttonPress = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("Player") && !IsButtonPress()) {

                buttonPress = true;
            gameObject.SetActive(false);
                

             }
    }

    public bool IsButtonPress()
    {
        return buttonPress;
    }
}
