using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
	public Button test;

	public void Return()
	{
		SceneManager.LoadScene(0);
	}

    public void Bac1()
    {
    	/*SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("nbMorts",0);*/
        test.interactable = true;
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
    	SceneManager.LoadScene(7);
        PlayerPrefs.SetInt("nbMorts",0);
    }

}
