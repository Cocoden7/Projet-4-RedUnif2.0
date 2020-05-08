using System.Collections;
using UnityEngine;

public class TeleporteurBehavior : MonoBehaviour
{
    public GameObject end;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // gameObject.SetActive(false);
            ParticleSystem particles = GameObject.FindGameObjectWithTag("TeleportParticles").GetComponent<ParticleSystem>();
            if(this.tag == "TP1")
            {
                particles.Play();
            }
            StartCoroutine(Corout());
            Rigidbody2D playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            // playerRb.position = GameObject.FindGameObjectWithTag("TP2").transform.position;
            playerRb.position = end.transform.position;
        }
    }

    IEnumerator Corout()
    {
        yield return new WaitForSeconds(10);
    }
}
