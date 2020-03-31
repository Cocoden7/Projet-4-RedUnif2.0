using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReformeBehavior : MonoBehaviour
{
    public int malus = 2;
    private ParticleSystem particles;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerBehavior player = FindObjectOfType<PlayerBehavior>();
            print("réforme");
            if (player.ST.tag == "PlayerMath")
            {
                print("Les étudiants en Math Appliquées ne craignenent pas la réforme, car ils savent bien calculer les crédits nécessaires");
            }
            else
            {
                if (player.nbCredit >= malus)
                {
                    particles = GameObject.FindGameObjectWithTag("CoinParticles").GetComponent<ParticleSystem>();
                    particles.Play();
                    player.nbCredit -= malus;
                }
                Destroy(gameObject);
            }
        }
    }
}
