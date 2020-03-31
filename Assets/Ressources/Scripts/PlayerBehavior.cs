using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Gère toutes les collisions du joueur, ses mouvements (clavier), sa mort, la collecte de crédits, lance le niveau suivant lorsque nécessaire

public class PlayerBehavior : MonoBehaviour
{
	public Rigidbody2D rb;
    public GameObject ST;
	Vector2 movement;
	private bool dead = false;
	public int nbCredit = 0;
    int creditsNeeded = 10;
    public GameObject NextLevelUI;
    private int ratio = 0;
    private int modifMouvement = 1;  // Variable pour modifié les déplacement du joueur (1 = normal, 0 = immobile, -1 = commandes inversees)

    string rightScore;


    void Start()
    {
        // Liste des tags possibles : PlayerElec, PlayerMeca, PlayerFyki, PlayerInfo, PlayerMath, PlayerGBio, PlayerGC
        ST.tag = "";
    }

    // Méthode appelée pour avoir les input du joueur
    void Update()
    {
        rightScore = "HighScore" + (SceneManager.GetActiveScene().buildIndex).ToString();
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

    void OnCollisionEnter2D(Collision2D col)
    { }

    /*
    Fonction qui gère le ramassage des pièces ainsi que la fin du niveau (quand on a assez de pièces)
    */
    void AddCredit(int nb = 1)
    {
    	nbCredit = nbCredit + nb;
    	if (nbCredit >= creditsNeeded) //si on a ramasse assez de credits
    	{
            print("AllCoins");
            if(PlayerPrefs.GetInt("nbMorts",0) > 10) // si on est mort plus de 10 fois
            {
                if( 10 > PlayerPrefs.GetInt(rightScore,0)) // si le score est meilleur que le precedent
                {
                    PlayerPrefs.SetInt(rightScore, 10);   
                }
            }
            else{
                print("dans le else");
                if( 20 - PlayerPrefs.GetInt("nbMorts",0) > PlayerPrefs.GetInt(rightScore,0))
                {
                    print("Set HighScore");
                    PlayerPrefs.SetInt(rightScore, 20 - PlayerPrefs.GetInt("nbMorts",0));   
                }
            }
            if(rightScore == "HighScore1" && PlayerPrefs.GetInt("WorldPass", 0) < 1)
            {
                PlayerPrefs.SetInt("WorldPass", 1);
            }
            else if(rightScore == "HighScore2" && PlayerPrefs.GetInt("WorldPass", 0) < 2)
            {
                PlayerPrefs.SetInt("WorldPass", 2);   
            }
            else if(rightScore == "HighScore3" && PlayerPrefs.GetInt("WorldPass", 0) < 3)
            {
                PlayerPrefs.SetInt("WorldPass", 3);
            }
            else if(rightScore == "HighScore4" && PlayerPrefs.GetInt("WorldPass", 0) < 4)
            {
                PlayerPrefs.SetInt("WorldPass", 4);
            }
            else if(rightScore == "HighScore5")
            {
                PlayerPrefs.SetInt("WorldPass", 5);
            }
            PlayerPrefs.SetInt("nbMorts",0);
            SetUINextLevel();
        }
    }

    /*
    Affiche le UI du next level et lance la méthode loadLevel
    */
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

    /*
    Fonction à appeler dès que le joueur meurt !!IMPORTANT, il faut appeler celle-ci
    */
    void Dead(string mort = "")
    {
        if (ST.tag == "PlayerElec" && mort == "elsecTrap")
        {
            print("Les gens en elec ne craignent pas l'electricite");
        }
        else if (ST.tag == "PlayerGBio" && mort == "ennemis")
        {
            print("Les gens en GBio connaissent les points faibles de l'anatomies des profs et sont à même de les mettre KO");
        }
        else if (ST.tag == "PlayerGC" && mort == "trou")
        {
            print("Les gens en GC ne tombent pas dans les trous du bâtiment");
        }
        else if (ST.tag == "Player" && mort == "canon")
        {
            print("Les gens en Info ne craignent pas les canons, car ils peuvent les pirater");
        }
        else
        {
            print(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("nbMorts", PlayerPrefs.GetInt("nbMorts") + 1);
            ratio = (nbCredit * 10) / 6;
            if (ratio > PlayerPrefs.GetInt(rightScore, 0))
            {
                PlayerPrefs.SetInt(rightScore, ratio);
            }
            dead = true;
            print("La mort est due à un(e) " + mort);
        }
    }

    void MoveUp()
    {
        rb.MovePosition(rb.position += new Vector2(0, 1 * modifMouvement));
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void MoveDown()
    {
        rb.MovePosition(rb.position += new Vector2(0, -1 * modifMouvement));
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void MoveRight()
    {
        rb.MovePosition(rb.position += new Vector2(1 * modifMouvement, 0));
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    void MoveLeft()
    {
        rb.MovePosition(rb.position += new Vector2(-1 * modifMouvement, 0));
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    // Les fonctions modifiant les deplacements appelees par les pieges sont ici dessous :

    void Bourre()
    {
        modifMouvement = -1;
        StartCoroutine(Attente(2.0f));
    }

    void Stop()
    {
        if (ST.tag == "PlayerFyKi")
        {
            print("Les gens en FyKi ne craignent pas les glues chimiques");
        }
        else
        {
            modifMouvement = 0;
            StartCoroutine(Attente(2.0f));
        }
    }

    // Les Coroutine dont ont besoin les pieges sur les deplacement sont ici dessous :

    IEnumerator Attente(float temps)
    {
        yield return new WaitForSeconds(temps);
        modifMouvement = 1;
    }
}
