using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class PlayerTP : MonoBehaviour
{
    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private string Level;
    [SerializeField] private float transitionScene;
    [SerializeField] private float transitionFade;
    [SerializeField] private Animator transitionAnimator;

    private void Start()
    {
        transitionScene = 1.3f;
        transitionFade = 0.5f;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animatorPlayer.SetBool("PlayerTP", true);
            StartCoroutine(WaitForAnimation());
        }
    }

    public IEnumerator WaitForAnimation()
    {
        yield return new WaitForSecondsRealtime(transitionFade);
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSecondsRealtime(transitionScene);
        SceneManager.LoadScene(Level);
    }
}
