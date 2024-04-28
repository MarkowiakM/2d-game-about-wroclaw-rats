using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Portal destinationPortal;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rufus") || other.CompareTag("Ruby"))
        {
            Debug.Log("teleporting");
            Teleport(other.gameObject);
        }
    }

    private void Teleport(GameObject player)
    {
        player.transform.position = destinationPortal.transform.position;
        player.transform.rotation = destinationPortal.transform.rotation;
    }
}
