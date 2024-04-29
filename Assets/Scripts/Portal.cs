using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Portal destinationPortal;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rufus") || other.CompareTag("Ruby"))
        {
            if(Vector2.Distance(other.transform.position, transform.position) > 0.3f)
            {
                Teleport(other.gameObject);
            }
        }
    }

    private void Teleport(GameObject player)
    {
        player.transform.position = destinationPortal.transform.position;
    }
}
