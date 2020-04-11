
using UnityEngine;

public class GlaceBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<PlayerBehavior>().Avance();
        }
    }
}
