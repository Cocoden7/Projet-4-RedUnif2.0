using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Gère toutes les collisions du joueur, ses mouvements (clavier), sa mort, la collecte de crédits, lance le niveau suivant lorsque nécessaire

public class StagePlayerBehavior : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;
	private bool dead = false;
	private int nbCredit = 0;
    int creditsNeeded = 5;
    public GameObject NextLevelUI;


    // Méthode appelée pour avoir les input du joueur
    void Update()
    {
        if(!dead)
    	{
            // Retourne -1 ou 1
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
    	}
        else
        {
            movement.x = 0;
            movement.y = 0;
            // Lance la methode GameOver dans GameManager
            FindObjectOfType<DeadMenu>().GameOver();
        }
    }
   
   // Méthode appelée pour appliquer les inputs au perso
   void FixedUpdate()
    {
        //print(movement);
    	rb.MovePosition(rb.position += movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    { 
        // Collision avec le vide
    	if(col.gameObject.CompareTag("vide"))
    	{
            Dead();
    	}
    }

    /*
    Fonction qui gère le ramassage des pièces ainsi que la fin du niveau (quand on a assez de pièces)
    */
    void AddCredit()
    {
    	nbCredit++;
    }

    void OnGUI()
    {
    	GUI.Label(new Rect (10, 10, 100, 20), " Credit : " + nbCredit);
    }

    /*
    Fonction à appeler dès que le joueur meurt !!IMPORTANT, il faut appeler celle-ci
    */
    void Dead()
    {
        PlayerPrefs.SetInt("CreditsStage", (PlayerPrefs.GetInt("CreditsStage",0) + nbCredit));
        dead = true;
    }
}
