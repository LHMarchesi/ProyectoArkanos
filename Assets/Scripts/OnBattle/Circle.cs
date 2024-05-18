using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Circle : MonoBehaviour
{

    private BattleManager battleManager;
    public bool isDestroy = false;
    [SerializeField] private string inputLetter;
    [SerializeField] private int points;
    [SerializeField] private int penaltyPoints;
    [SerializeField] private float deSpawnTime;
    [SerializeField] private Animator animator;
    
    private bool coroutineStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        deSpawnTime -= Time.deltaTime;

        DestroyCircle();
    }

    private void DestroyCircle()
    {
        if (deSpawnTime <= 0)
        {
            if (!coroutineStarted)
            {
            isDestroy = true;
            coroutineStarted = true;
            animator.SetBool("HitOut", true);
            StartCoroutine(enumerator());
            battleManager.PointsManager(-penaltyPoints);

            }

        }

        if (IsMouseOverCircle())
        {
            if (Input.anyKeyDown)
            {
                if (Input.inputString.ToUpper() == inputLetter.ToUpper())
                {
                    if (!coroutineStarted)
                    {
                        isDestroy = true;
                        coroutineStarted = true;
                        animator.SetBool("HitIn", true);    
                    StartCoroutine(enumerator());
                    battleManager.PointsManager(points);
                    }
                }
                else
                {
                    if (!coroutineStarted) 
                    {
                        isDestroy = true;
                        coroutineStarted = true;
                        animator.SetBool("HitOut", true);
                    StartCoroutine(enumerator());
                    battleManager.PointsManager(-points);
                    }
                }

            }
            
        }
    }
    private  bool IsMouseOverCircle()
    {
        // Obtiene la posición del mouse en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Ajusta la coordenada z para que coincida con la del círculo

        // Calcula la distancia entre la posición del círculo y la posición del mouse
        float distanceToCircle = Vector3.Distance(transform.position, mousePosition);

        // Si la distancia es menor que el radio del círculo, el mouse está dentro del círculo

        return distanceToCircle < GetComponent<CircleCollider2D>().radius;
    }


   

    private IEnumerator enumerator() {
     
            yield return new WaitForSeconds(1f);
             Destroy(gameObject);
        coroutineStarted = false;


    }
}
