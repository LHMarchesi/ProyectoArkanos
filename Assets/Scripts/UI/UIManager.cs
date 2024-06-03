using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI txtMultiplicator;
    [SerializeField] private TextMeshProUGUI txtPoints;
    
    public Slider progessBar;

    public void UpdateProgessBar(float progess, float maxPoints)
    {
        float update = progess / maxPoints;
        progessBar.value = update;
    }
    public void UpdateMultiplicator(int multiplicator)
    {
        txtMultiplicator.text = multiplicator.ToString();
    } 
    public void UpdatePoints(int points)
    {
        txtPoints.text = points.ToString();
    }
   
}
