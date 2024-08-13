using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTriggers : MonoBehaviour
{
    private bool isTrigger;
    [SerializeField] private GameObject item;
    [SerializeField] private Color defaultColor;

    private void Start()
    {
            item.GetComponent<SpriteRenderer>().color = defaultColor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == item)
        {
            isTrigger = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == item)
        {
            isTrigger = false;
            item.GetComponent<SpriteRenderer>().color = defaultColor;
            gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        }
    }

    public bool IsTrigered()
    {
        return isTrigger;
    }

}
