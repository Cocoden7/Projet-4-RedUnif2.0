using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Toutes les méthodes "OnClick()" des boutons du menu pause
public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public void OnClickPause()
    {
        Time.timeScale = 0f; // Freeze le jeu; (bien pour le slow mo)
        PauseMenuUI.SetActive(true);
    }

    public void OnClickMainMenu()
    {
        Time.timeScale = 1f; // Unfreeze le jeu
        SceneManager.LoadScene("StartMenu");  // Lance le main menu
    }

    public void OnClickOptions()
    {
        print("Options pressed");
    }

    public void OnClickResume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
    }
}
