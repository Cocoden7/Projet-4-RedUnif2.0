using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject buttons;
    public Button next;
    public float waitTime = 2f;

    public void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            } 
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if(popUpIndex == 0)
        {
            next.interactable = true;
        }
        /* if(popUpIndex == 2)
        {
            buttons.SetActive(true);
            next.interactable = false;
            if (pressAnyKey)
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 3)
        {
            if (creditRecolte)
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 4 || popUpIndex == 6 || popUpIndex == 8)
        {
            next.interactable = true;
        }
        else if(popUpIndex == 5 || popUpIndex == 7)
        {
            next.interactable = false;
            waitTime -= Time.deltaTime;
            popUpIndex++;
        } */
        /* else */ if(popUpIndex == 14)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Next()
    {
        popUpIndex++;
        print(popUpIndex);
    }
}