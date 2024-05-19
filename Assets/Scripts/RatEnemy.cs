using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float enemySpeed = 1.0f;
    public bool facingRight = false;

    Vector2 targetPosition;

    void Start()
    {
        targetPosition = endPoint.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, startPoint.position) < .1f)
        {
            targetPosition = endPoint.position;
            Flip();
        }

        if (Vector2.Distance(transform.position, endPoint.position) < .1f)
        {
            targetPosition = startPoint.position;
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemySpeed * Time.deltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
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
