using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiereBehavior : MonoBehaviour
{
    public GameObject Biere;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.SendMessageUpwards("Bourre", SendMessageOptions.DontRequireReceiver);
            Biere.SetActive(false);
        }
    }
}
