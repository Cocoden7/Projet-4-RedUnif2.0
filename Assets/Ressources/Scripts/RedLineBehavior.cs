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
        Vector3 posPlayer = FindObjectOfType<PlayerBehavior>().transform.position;

        // Si la ligne est trop loin derrière du joueur, on la remet à une distance raisonnable du joueur 
        if (posPlayer.y - transform.position.y > 10)
        {
            transform.position = new Vector2(transform.position.x, posPlayer.y - 10);
            print("trop loin");
        }
        transform.position = new Vector3(posPlayer.x, transform.position.y, -5f);
        transform.Translate(0f, speed*Time.deltaTime, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("collisifaezsoidne");
        if (col.tag == "Player")
        {
            print("Vous avez pris trop de retard !");
            col.SendMessageUpwards("Dead", "redLine", SendMessageOptions.DontRequireReceiver);
        }
    }
}
