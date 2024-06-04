using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsConected : MonoBehaviour
{
    [SerializeField] private GameObject item;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == item)
        {
            transform.position = item.transform.position;
            transform.rotation = item.transform.rotation;   
        }
    }
}
