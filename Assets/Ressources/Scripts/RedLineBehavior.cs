using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script gère les movements de la ligne rouge

public class RedLineBehavior : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, speed));
    }
}
