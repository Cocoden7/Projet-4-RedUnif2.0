using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public void OnClickPause()
    {
        Time.timeScale = 0f; // Freeze le jeu; bien pour le slow mo
        PauseMenuUI.SetActive(true);
        print("Pause pressed");
    }

    public void OnClickMainMenu()
    {
        print("Main menu pressed");
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
        print("Resume pressed");
    }
}
