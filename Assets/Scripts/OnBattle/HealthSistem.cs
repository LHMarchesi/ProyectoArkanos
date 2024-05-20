using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSistem : MonoBehaviour
{
    [SerializeField] private GameObject[] health;
    
    public void HpLost(int index)
    {
        health[index].gameObject.SetActive(false);
    }

    public void HpGain(int index)
    {
        health[index].gameObject.SetActive(true);
    }
}
