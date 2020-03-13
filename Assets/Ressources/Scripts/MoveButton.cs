using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
	Vector2 vec;
	Rigidbody2D Player;
	
    // Update is called once per frame
    void Start()
    {
        Player = FindObjectOfType<PlayerBehavior>().rb; 
    }

    public void Up()
    {
    	Player.MovePosition(Player.position += new Vector2(0,1));

    }

    public void Down()
    {
    	Player.MovePosition(Player.position += new Vector2(0,-1));
    }

    public void Left()
    {
    	Player.MovePosition(Player.position += new Vector2(-1,0));
    }

    public void Right()
    {
    	Player.MovePosition(Player.position += new Vector2(1,0));
    }
}
