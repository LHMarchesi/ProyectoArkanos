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
    [SerializeField] Dialogue fourthDialogue;

    private bool hasSecondDialogueStarted = false;
    private bool hasThirdDialogueStarted = false;
    private bool hasFourthDialogueStarted = false;


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
        if (circleScript.destroy && !hasSecondDialogueStarted) // Si el primer Circulo se destruye, empieza segundo dialogo
        {
            hasSecondDialogueStarted = true;

            firstdialogue.EndDialogueSecuence();
            StopAllCoroutines();

            Invoke("SeconDialogue", 1f); // Comienza el segundo dialogo luego de 1 segundos


        }
        if (circleScript2.hitIn && !hasFourthDialogueStarted)
        {
            hasFourthDialogueStarted = true;
            EasterEggSecuence();
            Invoke("EndFourthDialogue", 1f);
            
        }

        if (circleScript2.destroy && !hasThirdDialogueStarted && !hasFourthDialogueStarted) // Si el 
        {

            hasThirdDialogueStarted = true;
            secondDialogue.EndDialogueSecuence();

            Invoke("ThirdDialogue", 1f);
            Invoke("EndThirdDialogue", 3f);

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
    private void EndThirdDialogue()
    {
        thirdDialogue.EndDialogueSecuence();
    }
    private void EasterEggSecuence()
    {
        secondDialogue.EndDialogueSecuence();
        hasFourthDialogueStarted = true;
        fourthDialogue.StartDialogueSecuence();
    }

    private void EndFourthDialogue()
    {
        fourthDialogue.EndDialogueSecuence();
    }
}