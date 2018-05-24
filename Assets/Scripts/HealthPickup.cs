using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{
    void OnTriggerEnter()
    {

        Destroy(healthPack);  // Destroys the health pack
        Console.Debug("Gained 10 Health");
        PlayerBehaviour.health += 25; 
        if (PlayerBehaviour.health > 100)
        {
            PlayerBehaviour.health = 100;
        }

    }
}
