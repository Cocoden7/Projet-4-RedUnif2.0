using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    float templateHeight = 60f;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //Tri selon le score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = 0; j < highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry swap = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = swap;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();

        int max10 = 0;
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            if (max10 < 10)
            {
                CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                max10++;
            }
        }
    }

    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        entryTransform.Find("posText").GetComponent<Text>().text = rank.ToString();

        float finalScore = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = finalScore + "/20";

        string date = highscoreEntry.date;
        entryTransform.Find("dateText").GetComponent<Text>().text = date;

        entryTransform.Find("back").gameObject.SetActive(rank % 2 == 1);
        transformList.Add(entryTransform);
    }

    private void AddEntry(List<string> liste)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry {
            score = float.Parse(liste[0]), date = liste[1] };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);
        
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

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

    public void Retour()
    {
        SceneManager.LoadScene(12);
    }

    public void Reinitialise()
    {
        string emptyString = "";
        PlayerPrefs.SetString("highscoreTable", emptyString);
        PlayerPrefs.Save();
    }
}