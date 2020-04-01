﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Active le UI du dead menu
// Contient aussi les "OnClick()" du dead menu

public class DeadMenu : MonoBehaviour
{
    bool gameHasEnded = false;
    //bool restart = false;
    public float restartDelay = 1f;
    public GameObject deadMenuUI;
    public GameObject PauseButton;
    public GameObject MotionsButtons;
    public GameObject[] raisonMort;
    private int i;

    public void GameOver()
    {
        if(!gameHasEnded)
        {
            PauseButton.SetActive(false);
            MotionsButtons.SetActive(false);
            deadMenuUI.SetActive(true);

            /* i = ;
            raisonMort[i].SetActive(true); // Pour afficher les morts personnalisées
            */

            Time.timeScale = 0f; // Freeze le jeu; bien pour le slow mo
            FindObjectOfType<CameraBehavior>().incr = new Vector3(0,0,0); // Arrête la caméra
            gameHasEnded = true;
        }
    }

    // Methode appelée lorsqu'on appuie sur main menu
    public void MainMenu()
    {
        Time.timeScale = 1f; // Unfreeze le jeu
        SceneManager.LoadScene(0); 
    }

    // Methode appelée lorsqu'on appuie sur retry
    public void Retry()
    {
        Time.timeScale = 1f; // Unfreeze le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
