using UnityEngine;
using System.Collections;

public class RifleAmmoPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);  // Destroys the rifle ammo pack
        Debug.Log("Gained 5 rifle shells");
        ShootBullet.maxAmmo2 += 5;
    }
}
