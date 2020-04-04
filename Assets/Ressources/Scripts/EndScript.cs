using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{

    public Text Score;
    public Text Distinction;
    private float points;
    private float score1;
    private float score2;
    private float score3;
    private float score4;
    private float score5;

    // Start is called before the first frame update
    void Start()
    {
        score1 = (float)PlayerPrefs.GetInt("HighScore1", 0);
        score2 = (float)PlayerPrefs.GetInt("HighScore2", 0);
        score3 = (float)PlayerPrefs.GetInt("HighScore3", 0);
        score4 = (float)PlayerPrefs.GetInt("HighScore4", 0);
        score5 = (float)PlayerPrefs.GetInt("HighScore5", 0);
        points = (score1 + score2 + score3 + score4 + score5) / 5.0f;
        Score.text = points + "/20" ;

        if(points < 12.0f)
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
        string date = System.DateTime.UtcNow.ToString("dd/MM/yyyy");
        AddEntry(points, date);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("HighScore1", 0);
        PlayerPrefs.SetInt("HighScore2", 0);
        PlayerPrefs.SetInt("HighScore3", 0);
        PlayerPrefs.SetInt("HighScore4", 0);
        PlayerPrefs.SetInt("HighScore5", 0);
    }

    public void Scoreboard()
    {
        PlayerPrefs.SetInt("AncienneScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(13);
    }


    private void AddEntry(float score, string date)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry
        {
            score = score,
            date = date
        };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores;
        if (jsonString.Length == 0)
        {
            highscores = new Highscores() { highscoreEntryList = new List<HighscoreEntry>() };
        }
        else
        {
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public float score;
        public string date;
    }

}
