using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;

public class PlayerTP : MonoBehaviour
{
    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private string Level;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animatorPlayer.SetBool("PlayerTP", true);
            ScenesLoader.instance.LoadScene(Level);

        }
    }
}
