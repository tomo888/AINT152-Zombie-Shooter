using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);  // Destroys the health pack
        Debug.Log("Gained 25 health");
        PlayerBehaviour.health += 25;
        if (PlayerBehaviour.health > 100)
        {
            PlayerBehaviour.health = 100;
        }
    }
}
