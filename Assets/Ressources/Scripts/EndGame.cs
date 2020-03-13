using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
	bool gameHasEnded = false;
	public GameObject EndGameUI;
    public void EndMenu()
    {
        if(!gameHasEnded)
        {
        	print("slt");
            EndGameUI.SetActive(true);
            Time.timeScale = 0f; // Freeze le jeu; bien pour le slow mo
            FindObjectOfType<CameraBehavior>().incr = new Vector3(0,0,0); // Arrête la caméra
            gameHasEnded = true;
        }
    }

    public void Replay()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
