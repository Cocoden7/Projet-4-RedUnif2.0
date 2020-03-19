using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = FindObjectOfType<RedLineBehavior>().transform.position + new Vector3(0,1);
    }
}
