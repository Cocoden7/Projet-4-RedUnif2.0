using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Retour()
    {
        SceneManager.LoadScene(12);
    }

    public void Reinitialise()
    {
        
    }
}