using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private Vector2 speed;
    [SerializeField] private float timer;
    [SerializeField] private float[] changeBackgroundInTime; // Array de tiempo en que se cambia 
    [SerializeField] private Vector2[] newSpeed; // Array de velocidades 

    private int nextSpeedIndex;


    private void Update()
    {
        timer = BattleManager.Instance.timer;
        // Actualizar la posición UV del fondo en función de la velocidad y el tiempo
        background.uvRect = new Rect(background.uvRect.position + speed * Time.deltaTime, background.uvRect.size);
    }

    public void BackgroundSpeedHandleer(float timer)
    {
        if (nextSpeedIndex < changeBackgroundInTime.Length && timer >= changeBackgroundInTime[nextSpeedIndex])
        {
            ChangeSpeed(newSpeed[nextSpeedIndex]);
            nextSpeedIndex++;
        }
    }

    private void ChangeSpeed(Vector2 newSpeed)
    {
        // Actualizar la velocidad del fondo
        speed = newSpeed;
    }
}

