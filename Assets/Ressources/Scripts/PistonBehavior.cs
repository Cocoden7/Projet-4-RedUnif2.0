using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonBehavior : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rbManche;
    private Rigidbody2D rbBout;
    private Vector2 dir16;

    public Rigidbody2D rb;
    public GameObject Manche;
    public GameObject Bout;

    // Start is called before the first frame update
    void Start()
    {
        QuelleDirection();
        rbManche = Manche.GetComponent<Rigidbody2D>();
        rbBout = Bout.GetComponent<Rigidbody2D>();
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    { }

    IEnumerator Movement()
    {
        while (true)
        {
            // On etend le piston
            yield return new WaitForSeconds(1.0f);
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
        }
    }

    void QuelleDirection()
    {
        direction.x = 0.5f;
        dir16.x = 1/32f;
    }
}
