using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class AiFlying : MonoBehaviour
{
    public float speed;
    private Transform player;
    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    void CalculateDistance() // distance
    {
        float distance = MathF.Sqrt(Mathf.Pow(Player.transform.position.x - transform.position.x, 2) + Mathf.Pow(Player.transform.position.z - transform.position.z, 2));

       
        Vector3 player_pos = new Vector3(Player.transform.position.x, 0, transform.position.z);
        Vector3 enemy_pos = new Vector3(transform.position.x, 0, transform.position.z);
        float uDistance = Vector3.Distance(player_pos, enemy_pos);

        Vector3 enemy_to_player =  player_pos - enemy_pos;

        if (uDistance <= 5f)
        {
            Debug.Log("I will attack");
        }
        Debug.Log("Distance: " + distance);
        //Debug.Log("uDistance: " + uDistance);
        //Debug.Log("Magnitude: " + enemy_to_player.magnitude);
        //Debug.Log("sMagnitude: " + enemy_to_player.sqrMagnitude);
    }

    void CalculateAngle() //dot product
    {
        Vector3 enemy_forward = this.transform.up;
        Vector3 player_pos = Player.transform.position - this.transform.position;

        Debug.DrawRay(this.transform.position, enemy_forward * 10, Color.green,2);
        Debug.DrawRay(this.transform.position, player_pos * 10, Color.red, 2);

        float dot = enemy_forward.x * player_pos.x + enemy_forward.y * player_pos.y;
        float angle = Mathf.Acos(dot / (enemy_forward.magnitude * player_pos.magnitude));

        Debug.Log("Angle: " + angle * Mathf.Rad2Deg);
        Debug.Log("Unity Angle: " + Vector3.Angle(enemy_forward, player_pos));
    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
            CalculateDistance();
            CalculateAngle();
       }    
    }

   
}
