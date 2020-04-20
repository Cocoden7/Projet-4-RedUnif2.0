using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlaceBehavior : MonoBehaviour
{
    private Collider2D thisCol;
    private bool actif = true;

    void Start()
    {
        thisCol = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerBehavior player = col.GetComponent<PlayerBehavior>();
            if (!player.surglace && actif)
            {
                player.Avance();
            }
            if (actif)
            {
                player.surglace = true;
                StartCoroutine(Attente(col));
            }
        }
    }

    IEnumerator Attente(Collider2D colPlayer)
    {
        actif = false;
        while (thisCol.IsTouching(colPlayer))
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        actif = true;
    }
}
