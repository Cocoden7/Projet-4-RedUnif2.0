using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ce script gère les comportements des glues

public class GlueBehavior : MonoBehaviour
{
    public GameObject Glue;
    public GameObject upButton;
    public GameObject downButton;
    public GameObject rightButton;
    public GameObject leftButton;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(Attente());
        }
    }

    IEnumerator Attente()
    {
        Bouttons(false);
        yield return new WaitForSeconds(2.0f);
        Bouttons(true);
        Glue.SetActive(false);
    }

    void Bouttons(bool a)
    {
        upButton.GetComponent<Button>().interactable = a;
        downButton.GetComponent<Button>().interactable = a;
        rightButton.GetComponent<Button>().interactable = a;
        leftButton.GetComponent<Button>().interactable = a;
    }
}