using UnityEngine;
using System.Collections;

public class RifleAmmoPickup : MonoBehaviour
{
    void OnTriggerEnter()
    {

        Destroy(rifleAmmoPack);  // Destroys the rifle ammo pack
        Console.Debug("Gained 5 SMG shells");
        ShootBullet.maxAmmo2 += 5;

    }
}
