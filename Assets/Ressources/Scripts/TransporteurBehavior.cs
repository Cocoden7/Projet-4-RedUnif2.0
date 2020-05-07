using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporteurBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    Rigidbody2D playerRb;
    Vector2 movementX;
    Vector2 movementY;
    List<int> tabl;
    float vitesse;
    int nbCase;
    int joueurPris = 0;  // Nombre de case sur lesquelles le joueur doit encore etre traine
    bool attente = false;  // Boolean pour savoir si on doit attendre avant de remettre le collider
    bool peutBouger = false;  // Boolean indiquant quand le joueur est centre parrapport au transporteur
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
                if (joueurPris > 0 && !peutBouger)
                {
                    peutBouger = true;
                }
                // 1 = droite, 2 = gauche, 3 = haut, 4 = bas
                if (i == 1)
                {
                    while (a < 20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
                        rb.MovePosition(rb.position += movementX / 20);
                        a++;
                        if(joueurPris > 0  && peutBouger)
                        {
                            playerRb.MovePosition(playerRb.position += movementX / 20);
                            joueurPris--;
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
                        if (joueurPris > 0 && peutBouger)
                        {
                            playerRb.MovePosition(playerRb.position -= movementX / 20);
                            joueurPris--;
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
                        if (joueurPris > 0 && peutBouger)
                        {
                            playerRb.MovePosition(playerRb.position += movementY / 20);
                            joueurPris--;
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
                        if (joueurPris > 0 && peutBouger)
                        {
                            playerRb.MovePosition(playerRb.position -= movementY / 20);
                            joueurPris--;
                        }
                    }
                    a = 0;
                }
                if (attente)
                {
                    attente = false;
                    peutBouger = false;
                    rb.GetComponent<Collider2D>().enabled = true;
                }
                if (joueurPris == 0 && playerRb != null)
                {
                    playerRb.GetComponent<PlayerBehavior>().modifMouvement = 1;
                    attente = true;
                    playerRb = null;
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            rb.GetComponent<Collider2D>().enabled = false;
            print("collision ennemi");
            playerRb = col.GetComponent<Rigidbody2D>();
            playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            playerRb.GetComponent<PlayerBehavior>().modifMouvement = 0;
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

    // Fonction pour savoir sur combien de case le joueur doit être trainé (*20)
    int CombienDeCase()
    {
        if (rb.tag == "Ennemy2" || rb.tag == "Enemy3")
            return 50;
        else if (rb.tag == "Ennemy5")
            return 60;
        else
            return 40;
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
