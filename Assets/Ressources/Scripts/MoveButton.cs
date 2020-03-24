using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
	Vector2 vec;
	public Rigidbody2D Player;
	
    void Start()
    {
        Player = FindObjectOfType<PlayerBehavior>().rb; 
    }

    public void Up()
    {
        Player.SendMessageUpwards("MoveUp", SendMessageOptions.DontRequireReceiver);
    }

    public void Down()
    {
        Player.SendMessageUpwards("MoveDown", SendMessageOptions.DontRequireReceiver);
    }

    public void Left()
    {
        Player.SendMessageUpwards("MoveLeft", SendMessageOptions.DontRequireReceiver);
    }

    public void Right()
    {
        Player.SendMessageUpwards("MoveRight", SendMessageOptions.DontRequireReceiver);
    }
}
