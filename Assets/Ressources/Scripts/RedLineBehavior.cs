using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script gère les movements de la ligne rouge

public class RedLineBehavior : MonoBehaviour
{
    public float speed;
    public float acce;
    private bool seuil = false;
    void Update()
    {
        if (!seuil)
        {
            speed += acce;
            if(speed >= 0.01)
            {
                seuil = true;
            }
        }
        float posYPlayer = FindObjectOfType<PlayerBehavior>().transform.position.y;

        // Si la ligne est trop loin du joueur, on la remet à une distance raisonnable du joueur 
        if (posYPlayer - transform.position.y > 10)
        {
            transform.position = new Vector2(transform.position.x, posYPlayer - 10);
        }
        transform.Translate(new Vector2(0f, speed));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            print("Vous avez pris trop de retard !");
            col.SendMessageUpwards("Dead", SendMessageOptions.DontRequireReceiver);
        }
    }
}
