    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    Circle circleScript;
    Circle circleScript2;

    [SerializeField] GameObject circlePrefab;
    [SerializeField] GameObject circlePrefab2;

    [SerializeField] Dialogue firstdialogue;
    [SerializeField] Dialogue secondDialogue;
    [SerializeField] Dialogue thirdDialogue;

    private bool hasSecondDialogueStarted = false;
    private bool hasThirdDialogueStarted = false;

    void Start()
    {
        circleScript = circlePrefab.GetComponent<Circle>();
        circleScript2 = circlePrefab2.GetComponent<Circle>();
        circlePrefab.SetActive(false);
        StartCoroutine(FirstDialogue());

       
    }

    // Update is called once per frame
    void Update()
    {
        if (circleScript.isDestroy && !hasSecondDialogueStarted)
        {
            hasSecondDialogueStarted = true;

            firstdialogue.EndDialogueSecuence();
            StopAllCoroutines();

            Invoke("SeconDialogue", 1f);
        }

        if (circleScript2.isDestroy && !hasThirdDialogueStarted)
        {
            hasThirdDialogueStarted = true;
            secondDialogue.EndDialogueSecuence();
            

            Invoke("ThirdDialogue", 1f);
            Invoke("EndSecuence", 4f);
          
        }
    }

    private IEnumerator FirstDialogue()
    {
        yield return new WaitForSeconds(.5f);
       
        firstdialogue.StartDialogueSecuence();

        yield return new WaitForSeconds(2);

        circlePrefab.SetActive(true);

    }

    
    private void SeconDialogue()
    {
        secondDialogue.StartDialogueSecuence();
        circlePrefab2.SetActive(true);
    
    }

   

    private void ThirdDialogue()
    {
        thirdDialogue.StartDialogueSecuence();
    }

    private void EndSecuence()
    {
        thirdDialogue.EndDialogueSecuence();
    }
    
} 