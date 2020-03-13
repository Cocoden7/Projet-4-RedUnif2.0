using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSalleBehavior : MonoBehaviour
{
    public int OpeningDirection;
    // 1 => besoin d'un debut a gauche
    // 2 => besoin d'un debut au milieu
    // 3 => besoin d'un chemin a gauche

    private CheminTemplate templates;
    private int rand;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Chemin").GetComponent<CheminTemplate>();
    }

    void Spawn()
    {
        if (spawned == false)
        {
            print("Spawn nouveau bloc");
            if (OpeningDirection == 1)
            {
                rand = Random.Range(0, templates.debutGauche.Length);
                Instantiate(templates.debutGauche[rand], transform.position, templates.debutGauche[rand].transform.rotation);
            }
            else if (OpeningDirection == 2)
            {
                rand = Random.Range(0, templates.debutMilieu.Length);
                Instantiate(templates.debutMilieu[rand], transform.position, templates.debutMilieu[rand].transform.rotation);

            }
            else if (OpeningDirection == 3)
            {
                rand = Random.Range(0, templates.debutDroite.Length);
                Instantiate(templates.debutDroite[rand], transform.position, templates.debutDroite[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Invoke("Spawn", 0.01f);
        }
    }

}
