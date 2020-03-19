using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTrap : MonoBehaviour
{
	Collider2D electriccol;
	AudioSource audioSource;
	bool active;
    bool onScreen = false;  // Deja apparu a l'ecrant
    bool offScreen = true;  // Pas encore sortit de l'ecran

    // Start is called before the first frame update
    void Start()
    {
        electriccol = this.GetComponent<Collider2D>();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { }

    void Fin()
    {
        offScreen = false;
    }

    public void onCol()
    {
        if (onScreen && offScreen)
        {
            electriccol.enabled = true;
            audioSource.Play();
            active = true;
        }
    }

    public void offCol()
    {
        if (onScreen && offScreen)
        {
            electriccol.enabled = false;
            audioSource.Stop();
            active = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
    	if(active && col.tag == "Player")
    	{
            // Appelle la fonction  Dead() de col
    		col.SendMessageUpwards("Dead", SendMessageOptions.DontRequireReceiver);
    	}
        else if(col.tag == "MainCamera")
        {
            onScreen = true;
        }
    }
}
