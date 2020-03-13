using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
    	print("yo");
    	PlayerBehavior rb = col.gameObject.GetComponent<PlayerBehavior>();
    	rb.moveSpeed -= 3;
    	Destroy(gameObject);
    }
}
