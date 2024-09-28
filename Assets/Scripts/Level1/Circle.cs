using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Circle : MonoBehaviour
{
    public float DeSpawnTime { get; private set; }
    public int Points { get; private set; }

    public float initialDeSpawnTime;
    public int initialpoints;
    [SerializeField] private string inputLetter;
    [SerializeField] private Animator animator;

    private bool coroutineStarted = false;
    private Transform indicatorCircle;
    private Vector2 originalScale;
    public bool hitOut = false;
    public bool hitIn = false;
    public bool destroy = false;

    void Start()
    {
        setDespawnTime(initialDeSpawnTime);
        setPoints(initialpoints);

        animator = gameObject.GetComponent<Animator>();
        indicatorCircle = transform.Find("IndicatorCircle");
        originalScale = indicatorCircle.localScale;
    }


    void Update()
    {
        DeSpawnTime -= Time.deltaTime;

        UpdateIndicatorSize();

        if (DeSpawnTime <= 0)
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
        float scaleFactor = DeSpawnTime / initialDeSpawnTime;
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
                BattleManager.Instance.PointsManager(CalculateScore());
            }
            else
            {
                indicatorCircle.gameObject.SetActive(false);
                hitOut = true;
                animator.SetBool("HitOut", true);
                BattleManager.Instance.LostHp();
            }

            destroy = true;
            StartCoroutine(HitInDestroyAfterAnimation());
        }
    }

    private void HandleMiss()
    {
        if (!coroutineStarted)
        {
            indicatorCircle.gameObject.SetActive(false);
            coroutineStarted = true;
            StartCoroutine(HitOutDestroyAfterAnimation());
            animator.SetBool("HitOut", true);
            hitOut = true;
            destroy = true;
            BattleManager.Instance.LostHp();
        }
    }
    private int CalculateScore()
    {
        float indicatorRadius = indicatorCircle.GetComponent<CircleCollider2D>().radius * indicatorCircle.localScale.x;
        float circleRadius = GetComponent<CircleCollider2D>().radius;
        float precision = Mathf.Abs(indicatorRadius - circleRadius) / circleRadius;

        if (precision >= 0.2f)
        {
            BattleManager.Instance.GainMultiplicator();
            return Points * BattleManager.Instance.multiplicator;
        }
        else
        {
            BattleManager.Instance.LostMultiplicator();
            return Points;
        }
    }

    private bool IsMouseOverCircle()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        float distanceToCircle = Vector3.Distance(transform.position, mousePosition);
        return distanceToCircle < GetComponent<CircleCollider2D>().radius;
    }

    private IEnumerator HitInDestroyAfterAnimation()
    {
        indicatorCircle.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.32f);
        Destroy(gameObject);
        coroutineStarted = false;
    }
    private IEnumerator HitOutDestroyAfterAnimation()
    {
        indicatorCircle.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
        coroutineStarted = false;
    }

    public float setDespawnTime(float newtime)
    {
        DeSpawnTime = newtime;
        return newtime;
    }
    public int setPoints(int newPoints)
    {
        Points = newPoints;
        return newPoints;
    }

}
