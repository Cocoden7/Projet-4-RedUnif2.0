using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Gère les boutons du menu principal, gère aussi le HighScore

public class ButtonsScript : MonoBehaviour
{
	public Text CreditsStage;

    public void Start()
    {
        if(PlayerPrefs.GetInt("firstCo", 0) == 0)
        {
            PlayerPrefs.SetInt("firstCo", 1);
            SceneManager.LoadScene(9);
        }
        //PlayerPrefs.SetInt("firstCo", 0); // pour reset et avoir le tutoriel
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("WorldPass", 8);
    	CreditsStage.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
    }

	// OnClick du bouton Play
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(6);
        PlayerPrefs.SetInt("nbMorts",0); // remet la variable à 0 dans la bdd (indispensable car pas remis à 0 tout seul)
    }

    public void SlidingMenu()
    {
        SceneManager.LoadScene(8);
        PlayerPrefs.SetInt("nbMorts",0); // remet la variable à 0 dans la bdd (indispensable car pas remis à 0 tout seul)
    }
}
