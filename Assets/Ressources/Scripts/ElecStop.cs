using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecStop : MonoBehaviour
{
    public GameObject ElecTrap;

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
            print("fin ElecTrap");
            ElecTrap.SendMessageUpwards("Fin", SendMessageOptions.DontRequireReceiver);
        }
    }
}
