using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{

    public Text Score;
    public Text Distinction;
    public GameObject PopUp;
    private float points;

    // Start is called before the first frame update
    void Start()
    {
        points = PlayerPrefs.GetFloat("TotalScore");
        Score.text = points + "/20";

        if (points < 12.0f)
        {
            Distinction.text = "Aucune distinction";
        }
        else if(points >= 12.0f && points < 14.0f)
        {
            Distinction.text = "Satisfaction";
        }
        else if (points >= 14.0f && points < 16.0f)
        {
            Distinction.text = "Distinction";
        }
        else if (points >= 16.0f && points < 18.0f)
        {
            Distinction.text = "Grande distinction";
        }
        else if (points >= 18.0f && points < 19.0f)
        {
            Distinction.text = "La plus grande distinction";
        }
        else
        {
            Distinction.text = "Avec les félicitations du jury";
        }
    }

    public void Restart()
    {
        PopUp.SetActive(true);
    }

    public void Continue()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("HighScore1", 0);
        PlayerPrefs.SetInt("HighScore2", 0);
        PlayerPrefs.SetInt("HighScore3", 0);
        PlayerPrefs.SetInt("HighScore4", 0);
        PlayerPrefs.SetInt("HighScore5", 0);
        PlayerPrefs.SetInt("nbMorts1",0);
        PlayerPrefs.SetInt("nbMorts2",0);
        PlayerPrefs.SetInt("nbMorts3",0);
        PlayerPrefs.SetInt("nbMorts4",0);
        PlayerPrefs.SetInt("nbMorts5",0);
        PlayerPrefs.SetInt("WorldPass", 0);
        PlayerPrefs.SetFloat("TotalScore", 0.0f);
        PlayerPrefs.Save();
    }

    public void Annule()
    {
        PopUp.SetActive(false);
    }

    public void Scoreboard()
    {
        PlayerPrefs.SetInt("AncienneScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(13);
    }
}
