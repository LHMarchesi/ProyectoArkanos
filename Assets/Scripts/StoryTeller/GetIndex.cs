using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIndex : MonoBehaviour
{
    public ProgessionTracker progessionTracker;

    public void Awake()
    {
        GameObject progessionTrackerObject = GameObject.FindGameObjectWithTag("ProgessionTracker");
        if (progessionTrackerObject != null)
        {
            progessionTracker = progessionTrackerObject.GetComponent<ProgessionTracker>();
        }
    }

    public void RestartIndex()
    {
        progessionTracker.RestartIndex();
    }

    public void IndexAddOne()
    {
        progessionTracker.IncreaseLevelIndex();
    }
}
