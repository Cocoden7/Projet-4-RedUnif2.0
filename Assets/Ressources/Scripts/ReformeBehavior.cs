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
            print("reforme");
            // col.SendMessageUpwards("AddCredit", SendMessageOptions.DontRequireReceiver);
            if(FindObjectOfType<PlayerBehavior>().nbCredit >= malus)
            {
                particles = GameObject.FindGameObjectWithTag("CoinParticles").GetComponent<ParticleSystem>();
                particles.Play();
                FindObjectOfType<PlayerBehavior>().nbCredit -= malus;
            }
            Destroy(gameObject);
        }

    }

}
