using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ce script gère les comportements des glues

public class GlueBehavior : MonoBehaviour
{
    private Collider2D player;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.SendMessageUpwards("Stop", SendMessageOptions.DontRequireReceiver);
            gameObject.SetActive(false);
        }
    }
}