using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Gère les boutons du menu principal, gère aussi le HighScore

public class ButtonsScript : MonoBehaviour
{
	public Text highScore;

    public void Start()
    {	
        //PlayerPrefs.SetInt("HighScore",0);
    	highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

	// OnClick du bouton Play
    public void play()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("note",0);
    }
}
