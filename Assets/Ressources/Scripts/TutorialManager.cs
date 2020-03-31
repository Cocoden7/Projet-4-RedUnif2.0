using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    public GameObject credit;
    public GameObject buttons;
    public GameObject nextText;
    public Button next;

    private float waitTime = 4.0f;
    private int popUpIndex = 0;
    private Boolean moveDone = false;
    private Boolean coinDone = false;

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
            //nextText.SetActive(true);
        }
        if(popUpIndex == 2)
        {
            buttons.SetActive(true);
            next.interactable = false;
            //nextText.SetActive(false);
            if (moveDone)
            {
                DoneMouvement(false);
                next.interactable = true;
                popUpIndex++;
            }
        }
        /*else if(popUpIndex == 3)
        {
            credit.SetActive(true);
            if (coinDone)
            {
                DoneCredit(false);
                popUpIndex++;
            }
        }*/
        else if (popUpIndex == 4 || popUpIndex == 6 || popUpIndex == 8)
        {
            next.interactable = true;
            //nextText.setActive(true);
        }
        else if(popUpIndex == 5 || popUpIndex == 7)
        {
            next.interactable = false;
            //nextText.setActive(false);
            waitTime -= Time.deltaTime;
            if (waitTime < 0)
            {
                popUpIndex++;
                waitTime = 4.0f;
            }

        }
        else if(popUpIndex == 14)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Next()
    {
        popUpIndex++;
        print(popUpIndex);
    }
    void DoneMouvement(Boolean b)
    {
        moveDone = b;
    }
    void DoneCredit(Boolean b)
    {
        coinDone = b;
    }
}