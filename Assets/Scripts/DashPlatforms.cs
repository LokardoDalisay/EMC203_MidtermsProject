using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlatforms : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public DashManager dm;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platforms"))
        {
            Debug.Log("Player on the platform");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platforms"))
        {

            Debug.Log("Player has left the platform");
            Destroy(other.gameObject);  
            dm.dash_count++;
        }
    }
}
