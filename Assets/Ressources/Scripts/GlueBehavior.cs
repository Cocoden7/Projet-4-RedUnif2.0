using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerBehavior rb = col.gameObject.GetComponent<PlayerBehavior>();
        float speed = rb.moveSpeed;
        rb.moveSpeed = 0;
        gameObject.SetActive(false);
        //Attendre 2.5s
        rb.moveSpeed = speed;
        Destroy(gameObject);
    }
}