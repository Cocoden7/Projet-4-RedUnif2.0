using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Gère les boutons du menu principal, gère aussi le HighScore

public class ButtonsScript : MonoBehaviour
{
	public Text CreditsStage;
    public Button StageButton;

    public void Start()
    {
        //PlayerPrefs.SetInt("firstCo", 0); // pour reset et avoir le tutoriel
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("WorldPass", 8);
        //PlayerPrefs.SetInt("StagePass", 1);
        if(PlayerPrefs.GetInt("firstCo", 0) == 0)
        {
            SceneManager.LoadScene(9);
        }
        
    	CreditsStage.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        if(PlayerPrefs.GetInt("StagePass",0) < 1){
            StageButton.interactable = false;
            GameObject.Find("StageButton").SetActive(false);
        }
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
        PlayerPrefs.SetInt("AncienneScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(12);
    }
}
