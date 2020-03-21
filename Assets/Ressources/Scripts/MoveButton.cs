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
        Player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    	Player.MovePosition(Player.position += new Vector2(0,1));
        StartCoroutine(Attente());
    }

    public void Down()
    {
        Player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        Player.MovePosition(Player.position += new Vector2(0,-1));
        StartCoroutine(Attente());
    }

    public void Left()
    {
        Player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        Player.MovePosition(Player.position += new Vector2(-1,0));
        StartCoroutine(Attente());
    }

    public void Right()
    {
        Player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        Player.MovePosition(Player.position += new Vector2(1,0));
        StartCoroutine(Attente());
    }

    IEnumerator Attente()
    {
        yield return new WaitForSeconds(0.1f);
        Player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
