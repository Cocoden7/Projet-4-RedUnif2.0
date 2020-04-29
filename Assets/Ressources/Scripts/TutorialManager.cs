using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    public GameObject text;
    public Button next;
    public GameObject DeadMenuUi;
    public GameObject Panel;
    public Rigidbody2D rb;

    private float waitTime = 4.0f;
    private int popUpIndex = 0;
    private Boolean moveDone = false;
    private bool mort = false;
    Vector2 movementY;

    public void Update()
    {
        movementY.x = 0.0f;
        movementY.y = 1.0f;
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex && !mort)
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
            text.SetActive(true);
        }
        else if (popUpIndex == 4 || popUpIndex == 6 || popUpIndex == 8)
        {
            next.interactable = true;
            text.SetActive(true);
        }
        else if(popUpIndex == 5 || popUpIndex == 7)
        {
            next.interactable = false;
            text.SetActive(false);
            waitTime -= Time.deltaTime;
            if (waitTime < 0 && mort == false)
            {
                Next();
                waitTime = 4.0f;
            }

        }
        else if(popUpIndex == 14)
        {
            PlayerPrefs.SetInt("firstCo", 1);
            SceneManager.LoadScene(0);
        }
    }

    public void Next()
    {
        popUpIndex++;
        if(popUpIndex == 1 || popUpIndex == 2 || popUpIndex == 3 || popUpIndex == 6)
        {
            Next();
        }
    }

    public void DoneMouvement(Boolean b)
    {
        moveDone = b;
    }
    
    public void Mort()
    {
        mort = true;
        Panel.gameObject.SetActive(false);
        DeadMenuUi.gameObject.SetActive(true);
        Time.timeScale = 0f; // Freeze le jeu; bien pour le slow mo
    }

    public void Continuer()
    {
        mort = false;
        waitTime = 2.0f;
        if (popUpIndex == 5)
        {
            rb.MovePosition(rb.position -= movementY * 2);
        } else if (popUpIndex == 7)
        {
            rb.MovePosition(rb.position += movementY * 2);
        }
        DeadMenuUi.gameObject.SetActive(false);
        Panel.gameObject.SetActive(true);
        Time.timeScale = 1f; // Unfreeze le jeu
    }
}