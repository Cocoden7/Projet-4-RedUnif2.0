using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{


    public Rigidbody2D rb;
    Vector2 movementX;
    Vector2 movementY;
    bool test;
    // Start is called before the first frame update
    void Start()
    {
        movementX.y = 0.0f;
        movementX.x = 1.0f;
        movementY.y = 1.0f;
        movementY.x = 0.0f;
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    { }

    IEnumerator Movement()
    {
        List<int> tabl = QuelTabl();
        float vitesse = 1.0f;
        int a = 0;
        while (true)
        {
            test = true;
            foreach (var i in tabl)
            {
                // 1 = droite, 2 = gauche, 3 = haut, 4 = bas
                if (i == 1)
                {
                    while (a < 20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
                        rb.MovePosition(rb.position += movementX / 20);
                        a++;
                    }
                    a = 0;
                }
                else if (i == 2)
                {
                    while (a < 20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
                        rb.MovePosition(rb.position -= movementX / 20);
                        a++;
                    }
                    a = 0;
                }
                else if (i == 3)
                {
                    while (a < 20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
                        rb.MovePosition(rb.position += movementY / 20);
                        a++;
                    }
                    a = 0;
                }
                else if (i == 4)
                {
                    while (a < 20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
                        rb.MovePosition(rb.position -= movementY / 20);
                        a++;
                    }
                    a = 0;
                }
            }
            if (tabl[0] == 1)
            {
                rb.MovePosition(rb.position -= movementX * 2);
            }
            else if (tabl[0] == 2)
            {
                rb.MovePosition(rb.position += movementX * 2);
            }
            else if (tabl[0] == 3)
            {
                rb.MovePosition(rb.position -= movementY * 2);
            }
            else if (tabl[0] == 4)
            {
                rb.MovePosition(rb.position += movementY * 2);
            }
            test = false;
            yield return new WaitForSeconds(3.0f);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && test == true)
        {
            print("credit gagne!");
            col.SendMessageUpwards("Dead", SendMessageOptions.DontRequireReceiver);
        }
    }


    List<int> QuelTabl()
    {
        List<int> tabl = new List<int>();
        if (rb.tag == "fireball1")
        {
            tabl.Add(1);
            tabl.Add(1);
        }
        else if (rb.tag == "fireball2")
        {
            tabl.Add(2);
            tabl.Add(2);
        }
        else if (rb.tag == "fireball3")
        {
            tabl.Add(3);
            tabl.Add(3);
        }
        else if (rb.tag == "fireball4")
        {
            tabl.Add(4);
            tabl.Add(4);
        }
        return tabl;
    }

}