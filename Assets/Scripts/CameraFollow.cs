using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3 (0, 0, -10);
    [SerializeField]private Transform target;
    private float smoothTime = 0.25F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        
        Vector3 targetPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
