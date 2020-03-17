using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour
{

	public Rigidbody2D rb;
	Vector2 movementX;
	Vector2 movementY;
    // Start is called before the first frame update
    void Start()
    {
		movementX.y = 0.0f;
		movementX.x = 1.0f;
		movementY.y = 1.0f;
		movementY.x = 0.0f;
    	StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {}

    IEnumerator Movement()
    {
    	List<int> tabl = QuelTabl();
        float vitesse = QuelleVitesse();
        int a = 0;
    	while(true)
    	{
    		foreach (var i in tabl)
            {
                // 1 = droite, 2 = gauche, 3 = haut, 4 = bas
    		    if(i == 1)
    		    {
                    while(a<20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
    		    	    rb.MovePosition(rb.position += movementX/20);
                        a++;
                    }
                    a = 0;
    		    }
    		    else if(i == 2)
    		    {
                    while(a<20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
                        rb.MovePosition(rb.position -= movementX/20);
                        a++;
                    }
                    a = 0;
                }
    		    else if(i == 3)
    		    {
                    while(a<20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
                        rb.MovePosition(rb.position += movementY/20);
                        a++;
                    }
                    a = 0;
                }
    		    else if(i == 4)
    		    {
                    while(a<20)
                    {
                        yield return new WaitForSeconds(0.05f / vitesse);
                        rb.MovePosition(rb.position -= movementY/20);
                        a++;
                    }
                    a = 0;
    		    }
    		}
    	}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            print("collision ennemi");
    	    col.SendMessageUpwards("Dead", SendMessageOptions.DontRequireReceiver);
        }
    }

    float QuelleVitesse()
    {
        if(rb.tag == "Enemy1")
        {
            return 1.0f;
        }
        else if(rb.tag == "Enemy2")
        {
            return 2.0f;
        }
        return 1.0f;
    }

    List<int> QuelTabl()
    {
        List<int> tabl = new List<int>();
    	if(rb.tag == "Enemy1")
    	{
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(2);
            tabl.Add(2);
            tabl.Add(2);
    	}
        else if(rb.tag == "Enemy2")
        {
            tabl.Add(1);
            tabl.Add(3);
            tabl.Add(2);
            tabl.Add(4);
        }
        else if(rb.tag == "Enemy3")
        {
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(1);
            tabl.Add(2);
            tabl.Add(2);
            tabl.Add(2);
            tabl.Add(2);
        }
        else if(rb.tag == "Enemy4")
        {
            tabl.Add(4);
            tabl.Add(4);
            tabl.Add(4);
            tabl.Add(3);
            tabl.Add(3);
            tabl.Add(3);
        }
        else
        {
            tabl.Add(1);
            tabl.Add(2);
        }
        return tabl;
    }

}
