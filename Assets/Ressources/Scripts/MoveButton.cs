using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveButton : MonoBehaviour
{
	Vector2 vec;
	public Rigidbody2D Player;
    private GameObject Tuto;
	
    void Start()
    {
        Player = FindObjectOfType<PlayerBehavior>().rb;
        Tuto = FindObjectOfType<TutorialManager>().gameObject;
    }

    public void Up()
    {
        Player.SendMessageUpwards("MoveUp", SendMessageOptions.DontRequireReceiver);
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            Tuto.SendMessageUpwards("DoneMouvement", true, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Down()
    {
        Player.SendMessageUpwards("MoveDown", SendMessageOptions.DontRequireReceiver);
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            Tuto.SendMessageUpwards("DoneMouvement", true, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Left()
    {
        Player.SendMessageUpwards("MoveLeft", SendMessageOptions.DontRequireReceiver);
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            Tuto.SendMessageUpwards("DoneMouvement", true, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Right()
    {
        Player.SendMessageUpwards("MoveRight", SendMessageOptions.DontRequireReceiver);
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            Tuto.SendMessageUpwards("DoneMouvement", true, SendMessageOptions.DontRequireReceiver);
        }
    }
}
