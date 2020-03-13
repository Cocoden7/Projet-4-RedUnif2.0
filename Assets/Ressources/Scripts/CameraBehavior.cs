using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
	public Vector3 incr = new Vector3(0,1,0);

    // Update is called once per frame
    void Update()
    {
        transform.position += incr;
    }
}
