using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.SendMessageUpwards("AddCredit", 1, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
