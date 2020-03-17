﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Gère les boutons du menu principal, gère aussi le HighScore

public class ButtonsScript : MonoBehaviour
{
	public Text highScore0;
	public Text highScore1;

    public void Start()
    {	
    	print("AAAAAAAAAAAAAAAAAAAAAAAAA");
    	print(SceneManager.GetActiveScene().buildIndex);
        //PlayerPrefs.SetInt("HighScore0",0);  // Permet de remettre le highscore à 0
        //PlayerPrefs.SetInt("highScore1",0);  // Permet de remettre le highscore à 0
    	highScore0.text = PlayerPrefs.GetInt("HighScore0", 0).ToString();
    	highScore1.text = PlayerPrefs.GetInt("HighScore1",0).ToString();
    }

	// OnClick du bouton Play
    public void play()
    {
        SceneManager.LoadScene(6);
        PlayerPrefs.SetInt("nbMorts",0); // remet la variable à 0 dans la bdd (indispensable car pas remis à 0 tout seul)
    }
}
