using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Gère toutes les collisions du joueur, ses mouvements (clavier), sa mort, la collecte de crédits, lance le niveau suivant lorsque nécessaire

public class PlayerBehavior : MonoBehaviour
{
    public Sprite SpriteInfo;
    public Sprite SpriteMeca;
    public Sprite SpriteElec;
    public Sprite SpriteGc;
    public Sprite SpriteGbio;
    public Sprite SpriteMap;
    public Sprite SpriteFyki;
	public Rigidbody2D rb;
    public GameObject ST;
    public GameObject NextLevelUI;
    public Text Credits;
    public bool dead = false;
	public int nbCredit = 0;
    public int creditsNeeded = 60;
    public int modifMouvement = 1;  // Variable pour modifié les déplacement du joueur (1 = normal, 0 = immobile, -1 = commandes inversees)
    public bool surglace = false;  // pour savoir si il est toujours sur de la glace
    public GameObject GreenEffect;
    Image img;
    GameObject cam;

    private bool invincible = false;  // Si true, le player ne meurt pas
    private int ratio = 0;
    private string direction = "Haut";  // Variable indiquant dans quelle direction le joueur regarde (Haut, Bas, Droite, Gauche)
    Vector2 movement;
    string rightScore;
    Quaternion rot;

    


    void Start()
    {
        if(PlayerPrefs.GetString("TSTag","Untagged") == "PlayerInfo")
        {
            this.GetComponent<SpriteRenderer>().sprite = SpriteInfo;
        }
        else if(PlayerPrefs.GetString("TSTag","Untagged") == "PlayerElec")
        {
            this.GetComponent<SpriteRenderer>().sprite = SpriteElec;
        }
        else if(PlayerPrefs.GetString("TSTag","Untagged") == "PlayerMeca")
        {
            this.GetComponent<SpriteRenderer>().sprite = SpriteMeca;
        }
        else if(PlayerPrefs.GetString("TSTag","Untagged") == "PlayerFyki")
        {
            this.GetComponent<SpriteRenderer>().sprite = SpriteFyki;
        }
        else if(PlayerPrefs.GetString("TSTag","Untagged") == "PlayerMath")
        {
            this.GetComponent<SpriteRenderer>().sprite = SpriteMap;
        }
        else if(PlayerPrefs.GetString("TSTag","Untagged") == "PlayerGBio")
        {
            this.GetComponent<SpriteRenderer>().sprite = SpriteGbio;
        }
        else if(PlayerPrefs.GetString("TSTag","Untagged") == "PlayerGC")
        {
            this.GetComponent<SpriteRenderer>().sprite = SpriteGc;
        }
        Credits.text = nbCredit.ToString();
        // Liste des tags possibles : PlayerElec, PlayerMeca, PlayerFyki, PlayerInfo, PlayerMath, PlayerGBio, PlayerGC
        ST.tag = PlayerPrefs.GetString("TSTag", "Untagged");
        img = GreenEffect.GetComponent<Image>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rot = cam.transform.rotation;
    }

    // Méthode appelée pour avoir les input du joueur
    void Update()
    {
        Credits.text = nbCredit.ToString();
        rightScore = "HighScore" + (SceneManager.GetActiveScene().buildIndex).ToString();
        if(modifMouvement == 1)
            cam.transform.SetPositionAndRotation(cam.transform.position, rot);
        if (!dead)
    	{
            // Retourne -1 ou 1
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
    	}
        else if(!invincible)
        {
            movement.x = 0;
            movement.y = 0;
            // Lance la methode GameOver dans GameManager
            FindObjectOfType<DeadMenu>().GameOver();
        }
    }

    /*
    Fonction qui gère le ramassage des pièces ainsi que la fin du niveau (quand on a assez de pièces)
    */
    void AddCredit()
    {
    	nbCredit = nbCredit + 5;
    	if (nbCredit >= creditsNeeded) //si on a ramasse assez de credits
    	{
            if(rightScore == "HighScore1" && PlayerPrefs.GetInt("WorldPass", 0) < 1)
            {
                PlayerPrefs.SetInt("WorldPass", 1);
                if(PlayerPrefs.GetInt("nbMorts1",0) > 10) // si on est mort plus de 10 fois
                {
                    if( 10 > PlayerPrefs.GetInt(rightScore,0)) // si le score est meilleur que le precedent
                    {
                        PlayerPrefs.SetInt(rightScore, 10);   
                    }
                }
                else
                {
                    if( 20 - PlayerPrefs.GetInt("nbMorts1",0) > PlayerPrefs.GetInt(rightScore,0))
                    {
                        PlayerPrefs.SetInt(rightScore, 20 - PlayerPrefs.GetInt("nbMorts1",0));   
                    }
                }
            }
            else if(rightScore == "HighScore2" && PlayerPrefs.GetInt("WorldPass", 0) < 2)
            {
                PlayerPrefs.SetInt("WorldPass", 2);
                if(PlayerPrefs.GetInt("nbMorts2",0) > 10) // si on est mort plus de 10 fois
                {
                    if( 10 > PlayerPrefs.GetInt(rightScore,0)) // si le score est meilleur que le precedent
                    {
                        PlayerPrefs.SetInt(rightScore, 10);   
                    }
                }
                else
                {
                    if( 20 - PlayerPrefs.GetInt("nbMorts2",0) > PlayerPrefs.GetInt(rightScore,0))
                    {
                        PlayerPrefs.SetInt(rightScore, 20 - PlayerPrefs.GetInt("nbMorts2",0));   
                    }
                }
            }
            else if(rightScore == "HighScore3" && PlayerPrefs.GetInt("WorldPass", 0) < 3)
            {
                PlayerPrefs.SetInt("WorldPass", 3);
                PlayerPrefs.SetInt("StagePass",1);
                if(PlayerPrefs.GetInt("nbMorts3",0) > 10) // si on est mort plus de 10 fois
                {
                    if( 10 > PlayerPrefs.GetInt(rightScore,0)) // si le score est meilleur que le precedent
                    {
                        PlayerPrefs.SetInt(rightScore, 10);   
                    }
                }
                else
                {
                    if( 20 - PlayerPrefs.GetInt("nbMorts3",0) > PlayerPrefs.GetInt(rightScore,0))
                    {
                        PlayerPrefs.SetInt(rightScore, 20 - PlayerPrefs.GetInt("nbMorts3",0));   
                    }
                }
            }
            else if(rightScore == "HighScore4" && PlayerPrefs.GetInt("WorldPass", 0) < 4)
            {
                PlayerPrefs.SetInt("WorldPass", 4);
                if(PlayerPrefs.GetInt("nbMorts4",0) > 10) // si on est mort plus de 10 fois
                {
                    if( 10 > PlayerPrefs.GetInt(rightScore,0)) // si le score est meilleur que le precedent
                    {
                        PlayerPrefs.SetInt(rightScore, 10);   
                    }
                }
                else
                {
                    if( 20 - PlayerPrefs.GetInt("nbMorts4",0) > PlayerPrefs.GetInt(rightScore,0))
                    {
                        PlayerPrefs.SetInt(rightScore, 20 - PlayerPrefs.GetInt("nbMorts4",0));   
                    }
                }
            }
            else if(rightScore == "HighScore5")
            {
                PlayerPrefs.SetInt("WorldPass", 5);
                if(PlayerPrefs.GetInt("nbMorts5",0) > 10) // si on est mort plus de 10 fois
                {
                    if( 10 > PlayerPrefs.GetInt(rightScore,0)) // si le score est meilleur que le precedent
                    {
                        PlayerPrefs.SetInt(rightScore, 10);   
                    }
                }
                else
                {
                    if( 20 - PlayerPrefs.GetInt("nbMorts5",0) > PlayerPrefs.GetInt(rightScore,0))
                    {
                        PlayerPrefs.SetInt(rightScore, 20 - PlayerPrefs.GetInt("nbMorts5",0));   
                    }
                }
                float score1 = (float)PlayerPrefs.GetInt("HighScore1", 0);
                float score2 = (float)PlayerPrefs.GetInt("HighScore2", 0);
                float score3 = (float)PlayerPrefs.GetInt("HighScore3", 0);
                float score4 = (float)PlayerPrefs.GetInt("HighScore4", 0);
                float score5 = (float)PlayerPrefs.GetInt("HighScore5", 0);
                PlayerPrefs.SetFloat("TotalScore", (score1 + score2 + score3 + score4 + score5) / 5.0f);
                string date = System.DateTime.UtcNow.ToString("dd/MM/yyyy");
                AddEntry(PlayerPrefs.GetFloat("TotalScore"), date);
                SceneManager.LoadScene(12);
            }
            SetUINextLevel();
        }
    }

    /*
    Affiche le UI du next level et lance la méthode loadLevel
    */
    void SetUINextLevel()
    {
        invincible = true;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        NextLevelUI.SetActive(true);
        StartCoroutine(LoadLevel());
    }

    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2);
        invincible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        else if (ST.tag == "PlayerInfo" && mort == "canon")
        {
            print("Les gens en Info ne craignent pas les canons, car ils peuvent les pirater");
        }
        // Les tags Fyki, Meca et Math sont geres dans les script Glue, Piston et Reforme respectivement (plus facile comme ça)
        else if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            FindObjectOfType<TutorialManager>().SendMessageUpwards("Mort", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            if(rightScore == "HighScore1")
            {
                PlayerPrefs.SetInt("nbMorts1", PlayerPrefs.GetInt("nbMorts1") + 1);
            }
            else if(rightScore == "HighScore2")
            {
                PlayerPrefs.SetInt("nbMorts2", PlayerPrefs.GetInt("nbMorts2") + 1);
            }
            else if(rightScore == "HighScore3")
            {
                PlayerPrefs.SetInt("nbMorts3", PlayerPrefs.GetInt("nbMorts3") + 1);
            }
            else if(rightScore == "HighScore4")
            {
                PlayerPrefs.SetInt("nbMorts4", PlayerPrefs.GetInt("nbMorts4") + 1);
            }
            else if(rightScore == "HighScore5")
            {
                PlayerPrefs.SetInt("nbMorts5", PlayerPrefs.GetInt("nbMorts5") + 1);
            }
            ratio = (nbCredit * 10) / 60;
            if (ratio > PlayerPrefs.GetInt(rightScore, 0))
            {
                PlayerPrefs.SetInt(rightScore, ratio);
            }
            dead = true;
            print("La mort est due à un(e) " + mort);
            FindObjectOfType<DeadMenu>().SendMessageUpwards(mort, SendMessageOptions.DontRequireReceiver);
        }
    }

    // Les fonctions de mouvement :
    void MoveUp()
    {
        if (modifMouvement != 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.MovePosition(rb.position += new Vector2(0, 0.5f * modifMouvement));
            rb.MovePosition(rb.position += new Vector2(0, 0.5f * modifMouvement));
            if (modifMouvement == 1)
                direction = "Haut";
            else
                direction = "Bas";
            Centrer();
        }
    }

    void MoveDown()
    {
        if (modifMouvement != 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.MovePosition(rb.position += new Vector2(0, -0.5f * modifMouvement));
            rb.MovePosition(rb.position += new Vector2(0, -0.5f * modifMouvement));
            if (modifMouvement == 1)
                direction = "Bas";
            else
                direction = "Haut";
            Centrer();
        }
    }

    void MoveRight()
    {
        if (modifMouvement != 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            rb.MovePosition(rb.position += new Vector2(0.5f * modifMouvement, 0));
            rb.MovePosition(rb.position += new Vector2(0.5f * modifMouvement, 0));
            if (modifMouvement == 1)
                direction = "Droite";
            else
                direction = "Gauche";
            Centrer();
        }
    }

    void MoveLeft()
    {
        if (modifMouvement != 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            rb.MovePosition(rb.position += new Vector2(-0.5f * modifMouvement, 0));
            rb.MovePosition(rb.position += new Vector2(-0.5f * modifMouvement, 0));
            if (modifMouvement == 1)
                direction = "Gauche";
            else
                direction = "Droite";
            Centrer();
        }
    }

    void Centrer()
    {
        if (modifMouvement == 1)
        {
            RigidbodyConstraints2D constr = rb.constraints;
            rb.constraints = RigidbodyConstraints2D.None;
            float x = (float)(System.Math.Round(rb.position.x / 5.0f, 1) * 5.0);
            rb.MovePosition(new Vector2(x, rb.position.y));
            float y = (float)(System.Math.Round(rb.position.y / 5.0f, 1) * 5.0);
            rb.MovePosition(new Vector2(x, rb.position.y));
            rb.MovePosition(new Vector2(rb.position.x, y));
            rb.constraints = constr;
        }
    }

    // Les fonctions modifiant les deplacements appelees par les pieges sont ici dessous :

    // Fonction pour la biere
    void Bourre()
    {
        modifMouvement = -1;
        StartCoroutine(TourneCam());
    }

    // Fonction pour la glue
    void Stop()
    {
        if (ST.tag == "PlayerFyKi")
        {
            print("Les gens en FyKi ne craignent pas les glues chimiques");
        }
        else
        {
            cam.transform.SetPositionAndRotation(cam.transform.position, rot);
            modifMouvement = 0;
            GreenEffect.gameObject.SetActive(true);
            Color c = img.color;
            c.a = 1.0f;
            img.color = c;
            StartCoroutine(Attente());
        }
    }

    // Fonction pour la glace
    public void Avance()
    {
        cam.transform.SetPositionAndRotation(cam.transform.position, rot);
        modifMouvement = 0;
        surglace = true;
        StartCoroutine(Mouvement());
    }

    // Les Coroutine dont ont besoin les pieges sur les deplacement sont ici dessous :

    IEnumerator Attente()
    {
        yield return new WaitForSeconds(1.3f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(0.7f);
        GreenEffect.gameObject.SetActive(false);
        modifMouvement = 1;
    }

    IEnumerator FadeOut()
    {
        for(float f = 1.0f; f>=0.3f; f -= 0.05f)
        {
            Color c = img.color;
            c.a = f;
            img.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator TourneCam()
    {
        int i = 0;
        int a = 0;
        while (i < 12)
        {
            cam.transform.Rotate(0, 0, a * 0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 25)
        {
            cam.transform.Rotate(0, 0, -a*0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else if (i > 18)
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 25)
        {
            cam.transform.Rotate(0, 0, a*0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else if (i > 18)
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 25)
        {
            cam.transform.Rotate(0, 0, -a * 0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else if (i > 18)
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 25)
        {
            cam.transform.Rotate(0, 0, a * 0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else if (i > 18)
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 25)
        {
            cam.transform.Rotate(0, 0, -a * 0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else if (i > 18)
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 25)
        {
            cam.transform.Rotate(0, 0, a * 0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else if (i > 18)
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 25)
        {
            cam.transform.Rotate(0, 0, -a * 0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else if (i > 18)
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 25)
        {
            cam.transform.Rotate(0, 0, a * 0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else if (i > 18)
                a--;
            i++;
        }
        i = 0;
        a = 0;
        while (i < 12)
        {
            cam.transform.Rotate(0, 0, -a*0.1f);
            yield return new WaitForSeconds(0.01f);
            if (i < 6)
                a++;
            else
                a--;
            i++;
        }
        cam.transform.SetPositionAndRotation(cam.transform.position, rot);
        if (modifMouvement == -1)
        {
            modifMouvement = 1;
        }
    }

    IEnumerator Mouvement()
    {
        yield return new WaitForSeconds(0.1f);
        while (surglace)
        {
            surglace = false;
            int i = 0;
            while (i < 5)
            {
                if (direction == "Haut")
                {
                    rb.MovePosition(rb.position += new Vector2(0, 0.2f));
                }
                else if (direction == "Bas")
                {
                    rb.MovePosition(rb.position += new Vector2(0, -0.2f));
                }
                else if (direction == "Droite")
                {
                    rb.MovePosition(rb.position += new Vector2(0.2f, 0));
                }
                else if (direction == "Gauche")
                {
                    rb.MovePosition(rb.position += new Vector2(-0.2f, 0));
                }
                i++;
                yield return new WaitForSeconds(0.02f);
            }
            Centrer();
        }
        modifMouvement = 1;
        Centrer();
    }


    // Fonction et classes dont a besoin le scoreboard pour rajouter le score
    private void AddEntry(float score, string date)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry
        {
            score = score,
            date = date
        };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores;
        if (jsonString.Length == 0)
        {
            highscores = new Highscores() { highscoreEntryList = new List<HighscoreEntry>() };
        }
        else
        {
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public float score;
        public string date;
    }
}
