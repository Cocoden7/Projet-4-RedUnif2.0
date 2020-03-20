using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
	
	public Text HighScoreB1;
	public Text HighScoreB2;
	public Text HighScoreB3;
	public Text HighScoreM1;
	public Text HighScoreM2;

	public Button test;


	public void Start()
	{
		/*PlayerPrefs.SetInt("HighScore1",0);  // Permet de remettre le highscore à 0
        PlayerPrefs.SetInt("HighScore2",0);  // Permet de remettre le highscore à 0
        PlayerPrefs.SetInt("HighScore3",0);  // Permet de remettre le highscore à 0
        PlayerPrefs.SetInt("HighScore4",0);  // Permet de remettre le highscore à 0
        PlayerPrefs.SetInt("HighScore5",0);  // Permet de remettre le highscore à 0
        */
    	HighScoreB1.text = PlayerPrefs.GetInt("HighScore1", 0).ToString();
    	HighScoreB2.text = PlayerPrefs.GetInt("HighScore2",0).ToString();
    	HighScoreB3.text = PlayerPrefs.GetInt("HighScore3",0).ToString();
    	HighScoreM1.text = PlayerPrefs.GetInt("HighScore4",0).ToString();
    	HighScoreM2.text = PlayerPrefs.GetInt("HighScore5",0).ToString();
    }

	public void Return()
	{
		SceneManager.LoadScene(0);
	}

    public void Bac1()
    {
    	SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("nbMorts",0);
        //test.interactable = true;
    }

    public void Bac2()
    {
    	SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("nbMorts",0);
    }

    public void Bac3()
    {
    	SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("nbMorts",0);
    }

    public void Master1()
    {
    	SceneManager.LoadScene(4);
        PlayerPrefs.SetInt("nbMorts",0);
    }

    public void Master2()
    {
    	SceneManager.LoadScene(5);
        PlayerPrefs.SetInt("nbMorts",0);
    }

    public void LevelOne()
    {
    	SceneManager.LoadScene(8);
        PlayerPrefs.SetInt("nbMorts",0);
    }

    public void Stage()
    {
    	SceneManager.LoadScene(7);
    }
}
