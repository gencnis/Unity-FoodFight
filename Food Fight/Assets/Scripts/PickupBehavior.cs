using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    // Variable that stores reference to other script
    public GameBehavior gameManager;
    void Start()
    {
        // Finds Game Manager when it starts up
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // On collision store info of collision
    void OnCollisionEnter(Collision collision)
    {
        // If it is the player execute code
        if (collision.gameObject.name == "Player")
        {
            // Destroy the pickup
            Destroy(this.gameObject);

        }
    }
}
