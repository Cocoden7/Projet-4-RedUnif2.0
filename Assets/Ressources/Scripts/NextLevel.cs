using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    
public class NextLevel : MonoBehaviour
{
    public void LoadLevel()
    {
        // Charge la scène ayant le buildIndex actuel + 1
        print("dans load");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
