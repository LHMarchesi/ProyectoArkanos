using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Npc;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Npc.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Npc.SetActive(true);
            animator.SetBool("PlayerSpawn", true);
        }
    }

}
