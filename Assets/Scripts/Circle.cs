using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Circle : MonoBehaviour
{

    private GameManager gameManager;

    [SerializeField] private string inputLetter;
    [SerializeField] private int points;
    [SerializeField] private int penaltyPoints;
    [SerializeField] private float deSpawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            Destroy(gameObject);
            gameManager.PointsManager(-penaltyPoints);

        }

        if (IsMouseOverCircle())
        {
            if (Input.anyKeyDown)
            {
                if (Input.inputString.ToUpper() == inputLetter.ToUpper())
                {
                Destroy(gameObject);
                gameManager.PointsManager(points);
                }
                else
                {
                    Destroy(gameObject);
                    gameManager.PointsManager(-penaltyPoints);
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

    

}
