using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script gère les comportements des glues

public class GlueBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
        //Attendre 2.5s
        Destroy(gameObject);
    }
}