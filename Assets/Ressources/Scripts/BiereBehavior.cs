using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiereBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.SendMessageUpwards("Bourre", SendMessageOptions.DontRequireReceiver);
            gameObject.SetActive(false);
        }
    }
}
