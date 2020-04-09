using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporteurBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movementX;
    Vector2 movementY;
    Rigidbody2D playerRb;
    List<int> tabl;
    float vitesse;
    int nbCase;
    int joueurPris = 0;  // Nombre de case sur lesquelles le joueur doit encore etre traine
    bool attente = false;  // Boolean pour savoir si on doit attendre avant de remettre le collider
    // Start is called before the first frame update

    void Start()
    {
        movementX.y = 0.0f;
        movementX.x = 1.0f;
        movementY.y = 1.0f;
        movementY.x = 0.0f;
        StartCoroutine(Movement());
    }
    
    IEnumerator Movement()
    {
        tabl = QuelTabl();
        vitesse = QuelleVitesse();
        nbCase = CombienDeCase();
        int a = 0;
        while (true)
        {
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
                        if(joueurPris > 0)
                        {
                            playerRb.MovePosition(playerRb.position += movementX / 20);
                        }
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
                        if (joueurPris > 0)
                        {
                            playerRb.MovePosition(playerRb.position -= movementX / 20);
                        }
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
                        if (joueurPris > 0)
                        {
                            playerRb.MovePosition(playerRb.position += movementY / 20);
                        }
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
                        if (joueurPris > 0)
                        {
                            playerRb.MovePosition(playerRb.position -= movementY / 20);
                        }
                    }
                    a = 0;
                }
                if (joueurPris > 0)
                    joueurPris--;
                if (attente)
                {
                    attente = false;
                    rb.GetComponent<Collider2D>().enabled = true;
                }
                if (nbCase == 0 && playerRb != null)
                {
                    playerRb.GetComponent<PlayerBehavior>().modifMouvement = 1;
                    attente = false;
                    playerRb = null;
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            print("collision ennemi");
            playerRb = col.GetComponent<Rigidbody2D>();
            playerRb.GetComponent<PlayerBehavior>().modifMouvement = 0;
            playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.GetComponent<Collider2D>().enabled = false;
            joueurPris = nbCase;
        }
    }

    float QuelleVitesse()
    {
        if (rb.tag == "Enemy2" || rb.tag == "Enemy5")
        {
            return 2.0f;
        }
        return 1.0f;
    }

    int CombienDeCase()
    {
        if (rb.tag == "Ennemy2" || rb.tag == "Enemy3")
            return 1;
        else if (rb.tag == "Ennemy5")
            return 3;
        else
            return 2;
    }

    List<int> QuelTabl()
    {
        List<int> tabl = new List<int>();
        if (rb.tag == "Enemy1")
        {
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(2);
            tabl.Add(2);
            tabl.Add(2);
        }
        else if (rb.tag == "Enemy2")
        {
            tabl.Add(1);
            tabl.Add(3);
            tabl.Add(2);
            tabl.Add(4);
        }
        else if (rb.tag == "Enemy3")
        {
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(2);
            tabl.Add(2);
            tabl.Add(2);
            tabl.Add(2);
        }
        else if (rb.tag == "Enemy4")
        {
            tabl.Add(4);
            tabl.Add(4);
            tabl.Add(4);
            tabl.Add(3);
            tabl.Add(3);
            tabl.Add(3);
        }
        else if (rb.tag == "Enemy5")
        {
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(4);
            tabl.Add(4);
            tabl.Add(2);
            tabl.Add(2);
            tabl.Add(3);
            tabl.Add(3);
        }
        else
        {
            tabl.Add(1);
            tabl.Add(2);
        }
        return tabl;
    }
}
