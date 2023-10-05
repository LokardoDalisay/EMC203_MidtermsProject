using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bullet_pos;

    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    { 
        float distance = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log("I will shoot" + distance);

        if (distance < 7)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                ShootPlayer();
            }
        }
    }

    private void ShootPlayer()
    {
        Instantiate(bullet, bullet_pos.position, Quaternion.identity);
    }
}
