using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Circle : MonoBehaviour
{

    private BattleManager battleManager;
    public bool hitOut = false;
    public bool hitIn = false;
    public bool destroy = false;
    [SerializeField] private string inputLetter;
    [SerializeField] private int points = 10;
    [SerializeField] private float deSpawnTime;
    [SerializeField] private Animator animator;

    private bool coroutineStarted = false;
    private Transform indicatorCircle;
    private Vector3 originalScale;
    private float initialDeSpawnTime;


    void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        animator = gameObject.GetComponent<Animator>();
        indicatorCircle = transform.Find("IndicatorCircle");
        originalScale = indicatorCircle.localScale;
        initialDeSpawnTime = deSpawnTime;
    }

 
    void Update()
    {
        deSpawnTime -= Time.deltaTime;

        UpdateIndicatorSize();

        if (deSpawnTime <= 0)
        {
            HandleMiss();
        }
        else if (IsMouseOverCircle() && Input.anyKeyDown)
        {
            HandleInput();
        }
    }
    private void UpdateIndicatorSize()
    {
        float scaleFactor = deSpawnTime / initialDeSpawnTime;
        indicatorCircle.localScale = originalScale * scaleFactor;
    }

    private void HandleInput()
    {
        if (!coroutineStarted)
        {
            coroutineStarted = true;
            if (Input.inputString.ToUpper() == inputLetter.ToUpper())
            {
                indicatorCircle.gameObject.SetActive(false);
                hitIn = true;
                animator.SetBool("HitIn", true);
                battleManager.PointsManager(CalculateScore());
            }
            else
            {
                indicatorCircle.gameObject.SetActive(false);
                hitOut = true;
                animator.SetBool("HitOut", true);
                battleManager.LostHp();
            }

            destroy = true;
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private void HandleMiss()
    {
        if (!coroutineStarted)
        {
            indicatorCircle.gameObject.SetActive(false);
            coroutineStarted = true;
            StartCoroutine(DestroyAfterAnimation());
            animator.SetBool("HitOut", true);
            hitOut = true;
            destroy = true;
            battleManager.LostHp();
        }
    }
    private int CalculateScore()
    {
        float indicatorRadius = indicatorCircle.GetComponent<CircleCollider2D>().radius * indicatorCircle.localScale.x;
        float circleRadius = GetComponent<CircleCollider2D>().radius;
        float precision = Mathf.Abs(indicatorRadius - circleRadius) / circleRadius;

        if (precision >= 0.2f) 
        {
            battleManager.GainMultiplicator();
            return points * battleManager.multiplicator;
        }
        else
        {
            battleManager.LostMultiplicator();
            return points;
        }
    }

    private bool IsMouseOverCircle()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; 
        float distanceToCircle = Vector3.Distance(transform.position, mousePosition);
        return distanceToCircle < GetComponent<CircleCollider2D>().radius;
    }

    private IEnumerator DestroyAfterAnimation()
    {
        indicatorCircle.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        coroutineStarted = false;
    }

}
