using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTrap : MonoBehaviour
{
	Collider2D electriccol;
	AudioSource audio;
	bool test;

    // Start is called before the first frame update
    void Start()
    {
        electriccol = this.GetComponent<Collider2D>();
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCol()
    {
    	electriccol.enabled = true;
    	audio.Play();
    	test = true;
    }

    public void offCol()
    {
    	electriccol.enabled = false;
    	test = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
    	if(test && col.tag == "Player")
    	{
            // Appelle la fonction  Dead() de col
    		col.SendMessageUpwards("Dead", SendMessageOptions.DontRequireReceiver);
    	}
    }
}
