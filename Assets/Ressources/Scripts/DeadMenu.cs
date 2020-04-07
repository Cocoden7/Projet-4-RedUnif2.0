using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private string text;
    public Text texte;

    public void GameOver()
    {
        if(!gameHasEnded)
        {
            PauseButton.SetActive(false);
            MotionsButtons.SetActive(false);
            deadMenuUI.SetActive(true);
            print(text);
            texte.text = text;
            Time.timeScale = 0f; // Freeze le jeu; bien pour le slow 
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

    public void canon() { text = "Explosion au labo de chimie!"; }
    public void trou() { text = "Vous êtes tombés dans le bas de la ville..."; }
    public void ennemis() { text = "Les pièges tendus par les professeurs ont eu raison de vous..."; }
    public void elsecTrap() { text = "Mais faites attention aux courts-cicruits..."; }
    public void redLine() { text = "Vous avez raté votre examen et avez obtenu 9."; }


}
