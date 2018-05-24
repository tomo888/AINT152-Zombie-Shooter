using UnityEngine;
using System.Collections;

public class SMGAmmoPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);  // Destroys the SMG ammo pack
        Debug.Log("Gained 30 SMG bullets");
        ShootBullet.maxAmmo1 += 30;
    }
}
