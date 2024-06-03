using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTriggers : MonoBehaviour
{
    private bool isTrigger;
    [SerializeField] private GameObject item;
    [SerializeField] private Color defaultColor;
<<<<<<< HEAD
    [SerializeField] private Animator animator;
=======
>>>>>>> Devv

    private void Start()
    {
            item.GetComponent<SpriteRenderer>().color = defaultColor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == item)
        {
            isTrigger = true;
<<<<<<< HEAD
            animator.SetBool("IsConected", true);
=======

>>>>>>> Devv
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == item)
        {
            isTrigger = false;
            item.GetComponent<SpriteRenderer>().color = defaultColor;
            gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
            animator.SetBool("IsConected", false);
        }
    }

    public bool IsTrigered()
    {
        return isTrigger;
    }

}
