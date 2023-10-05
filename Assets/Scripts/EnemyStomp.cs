using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    public float bounce;
    public Rigidbody2D rb2d;
    public DashManager dm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            rb2d.velocity = new Vector2 (rb2d.velocity.x, bounce);
            dm.dash_count++;
        }
    }
}
