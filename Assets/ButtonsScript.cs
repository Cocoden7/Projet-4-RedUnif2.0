using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    // OnClick du bouton Play
    public void play()
    {
        SceneManager.LoadScene(0);
    }
}
