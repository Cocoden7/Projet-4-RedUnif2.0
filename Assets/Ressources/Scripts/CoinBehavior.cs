using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinBehavior : MonoBehaviour
{
    private GameObject Tuto;
    // Start is called before the first frame update
    void Start()
    {
        Tuto = FindObjectOfType<TutorialManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.SendMessageUpwards("AddCredit", 1, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
            if(SceneManager.GetActiveScene().name == "Tutorial")
            {
                Tuto.SendMessageUpwards("DoneCredit", true, SendMessageOptions.DontRequireReceiver);
            }
        }

    }

}
