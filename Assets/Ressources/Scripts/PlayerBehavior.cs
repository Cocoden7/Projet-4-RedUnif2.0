using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Gère toutes les collisions du joueur, ses mouvements (clavier), sa mort, la collecte de crédits, lance le niveau suivant lorsque nécessaire

public class PlayerBehavior : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D col)
    {
        // La ligne rouge rattrape le joueur
        if (col.gameObject.CompareTag("RedLine"))
        {
            print("Vous avez pris trop de retard !");
            Dead();
        }
    }


    void AddCredit()
    {
    	nbCredit++;
    	if (nbCredit >= creditsNeeded)
    	{
    		if(20 - PlayerPrefs.GetInt("note",0) > PlayerPrefs.GetInt("HighScore"))
    		{
    			PlayerPrefs.SetInt("HighScore", 20 - PlayerPrefs.GetInt("note",0));
    		}
            SetUINextLevel();
        }
    }

    // Affiche le UI du next level et lance la méthode loadLevel
    void SetUINextLevel()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        FindObjectOfType<CameraBehavior>().incr = new Vector3(0, 0, 0); // Arrête la caméra
        NextLevelUI.SetActive(true); // L'appel de la méthode LoadLevel() se fait dans l'animation du UI
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
    	GUI.Label(new Rect (10, 10, 100, 20), " Credit : " + nbCredit);
    }

    void Dead()
    {
    	PlayerPrefs.SetInt("note", PlayerPrefs.GetInt("note") + 1);
        dead = true;
    }
}
