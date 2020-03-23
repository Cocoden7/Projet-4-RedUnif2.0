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
        Player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        CentrerPlayer();
    }

    public void Down()
    {
    	Player.MovePosition(Player.position += new Vector2(0,-1));
        Player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        CentrerPlayer();
    }

    public void Left()
    {
    	Player.MovePosition(Player.position += new Vector2(-1,0));
        Player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        CentrerPlayer();
    }

    public void Right()
    {
    	Player.MovePosition(Player.position += new Vector2(1,0));
        Player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        CentrerPlayer();
    }

    void CentrerPlayer()
    {
        int x = (int)Player.position.x;
        int y = (int)Player.position.y;
        print((x, y));
        Player.MovePosition(new Vector2((float)x + 0.5f, (float)y + 0.5f));
    }
}
