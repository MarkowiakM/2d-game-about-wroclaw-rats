using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float platformSpeed  = 1.5f;

    Vector2 targetPosition;

    void Start()
    {
        targetPosition = endPoint.position;
    }
    
    void Update() {
        if (Vector2.Distance(transform.position, startPoint.position) < .1f) 
            targetPosition = endPoint.position;
            
        if (Vector2.Distance(transform.position, endPoint.position) < .1f) 
            targetPosition = startPoint.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, platformSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (transform.position != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(transform.position, startPoint.position);
            Gizmos.DrawLine(transform.position, endPoint.position);
        }
    }
}
