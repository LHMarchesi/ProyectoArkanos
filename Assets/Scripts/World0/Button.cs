using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Button : MonoBehaviour
{
   
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool buttonPress;
    [SerializeField] private Animator animator;

    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.sprite = spriteRenderer.sprite;
        buttonPress = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !IsButtonPress())
        {
            animator.SetBool("IsConected", true);
            buttonPress = true;
        }


    }

    public bool IsButtonPress()
    {
        return buttonPress;
    }
}
