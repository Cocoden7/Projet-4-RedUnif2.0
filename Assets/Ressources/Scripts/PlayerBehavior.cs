using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;
	private bool dead = false;
	private int nbCredit = 0;
    int creditsNeeded = 5;
    public GameObject NextLevelUI;



    /*float dirX, dirY;

    // Move speed variable can be set in Inspector with slider
    [Range(1f, 20f)]
    public float moveSpeed = 5f;
*/
    // Update is called once per frame
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
 
   void FixedUpdate()
    {
        print(movement);
    	rb.MovePosition(rb.position += movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    { 
        // Collision avec le vide
    	if(col.gameObject.CompareTag("vide"))
    	{
    		print("collision");
            Dead();
    	}
    }

    void AddCredit()
    {
    	nbCredit++;
    	if (nbCredit >= creditsNeeded)
    	{
            SetUINextLevel();
        }
    }

    // Affiche le UI du next level et lance la méthode loadLevel
    void SetUINextLevel()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        FindObjectOfType<CameraBehavior>().incr = new Vector3(0, 0, 0); // Arrête la caméra
        NextLevelUI.SetActive(true); // L'appel de la méthode se fait dans l'animation du UI
        Time.timeScale = 1.0f;
        print("ui active");
    }

    void OnGUI()
    {
    	GUI.Label(new Rect (10, 10, 100, 20), " Credit : " + nbCredit);
    }

    void Dead()
    {
        dead = true;
    }
}
