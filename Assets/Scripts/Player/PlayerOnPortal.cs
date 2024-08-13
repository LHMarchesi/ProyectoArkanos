using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnPortal : MonoBehaviour
{
    [SerializeField] private Animator animatorPortal;


    private void Start()
    {
        animatorPortal.SetBool("PlayerTrigger", false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            animatorPortal.SetBool("PlayerTrigger", true);
        }
        else
        {
            animatorPortal.SetBool("PlayerTrigger", false) ;
        }
    }
}
