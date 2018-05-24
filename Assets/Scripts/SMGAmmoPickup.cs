using UnityEngine;
using System.Collections;

public class SMGAmmoPickup : MonoBehaviour
{
    void OnTriggerEnter()
    {

        Destroy(SMGAmmoPack);  // Destroys the SMG ammo pack
        Console.Debug("Gained 30 SMG bullets");
        ShootBullet.maxAmmo1 += 30;

    }
}
