using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrouBehavior : MonoBehaviour
{
    private Collider2D colider;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.2f);
        colider.SendMessageUpwards("Dead", "trou", SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            print("T'es tombé dans le trou boulet... -_-");
            colider = col;
            StartCoroutine(Dead());
        }
    }
}
