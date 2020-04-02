using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonBehavior : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 dir16;
    private Rigidbody2D rbManche;
    private Rigidbody2D rbBout;
    private BoxCollider2D colDet;

    public Rigidbody2D rb;
    public GameObject Manche;
    public GameObject Bout;
    public GameObject Detecteur;

    // Start is called before the first frame update
    void Start()
    {
        QuelleDirection();
        rbManche = Manche.GetComponent<Rigidbody2D>();
        rbBout = Bout.GetComponent<Rigidbody2D>();
        colDet = Detecteur.GetComponent<BoxCollider2D>();
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    { }

    IEnumerator Movement()
    {
        while (true)
        {
            if (FindObjectOfType<PlayerBehavior>().ST.tag == "PlayerMeca")
            {
                print("Les etudiants en meca ne craignent pas les pistons");
                StopCoroutine(Movement());
            }
            // On etend le piston
            yield return new WaitForSeconds(1.0f);
            colDet.enabled = false;
            rbBout.MovePosition(rbBout.position += direction);
            rbManche.MovePosition(rbManche.position += (direction - dir16));
            yield return new WaitForSeconds(0.05f);
            rbBout.MovePosition(rbBout.position += direction);
            rbManche.MovePosition(rbManche.position += (direction - dir16));

            // Puis on le remet normal
            yield return new WaitForSeconds(1.0f);
            rbBout.MovePosition(rbBout.position -= direction);
            rbManche.MovePosition(rbManche.position -= (direction - dir16));
            yield return new WaitForSeconds(0.05f);
            rbBout.MovePosition(rbBout.position -= direction);
            rbManche.MovePosition(rbManche.position -= (direction - dir16));
            colDet.enabled = true;
        }
    }

    void QuelleDirection()
    {
        if(rb.tag == "PistonDroite")
        {
            direction.x = 0.5f;
            dir16.x = 1 / 32f;
        }
        else if (rb.tag == "PistonGauche")
        {
            direction.x = -0.5f;
            dir16.x = -1 / 32f;
        }
        else if (rb.tag == "PistonHaut")
        {
            direction.y = 0.5f;
            dir16.y = 1 / 32f;
        }
        else if (rb.tag == "PistonBas")
        {
            direction.y = -0.5f;
            dir16.y = -1 / 32f;
        }
    }
}
