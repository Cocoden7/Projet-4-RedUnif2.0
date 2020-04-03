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

    public void SlidingMenu()
    {
        SceneManager.LoadScene(8);
        PlayerPrefs.SetInt("nbMorts",0); // remet la variable à 0 dans la bdd (indispensable car pas remis à 0 tout seul)
    }
    public void Shop()
    {
    	SceneManager.LoadScene(11);
        PlayerPrefs.SetInt("nbMorts",0);
    }
    public void Stage()
    {
    	SceneManager.LoadScene(7);
    }

    public void GoToStart()
    {
        SceneManager.LoadScene(0);
    }

    public void Scoreboard()
    {
        SceneManager.LoadScene(13);
    }
}
