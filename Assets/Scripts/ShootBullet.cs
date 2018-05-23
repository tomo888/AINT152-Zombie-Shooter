using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;

    public int maxClip = 10;
    public static int currentClip;

    public int maxClip1 = 30;
    public static int currentClip1;
    public static int maxAmmo1;

    public int maxClip2 = 1;
    public static int currentClip2;
    public static int maxAmmo2;


    public float reloadTime = 1f;
    private bool isReloading = false;

    private void Start()
    {
        currentClip = 10;
        currentClip1 = 30;
        currentClip2 = 1;
    }

    private void OnEnable()
    {
        isReloading = false;
    }

    void SetFiring()
    {
        isFiring = false;
    }
    void Fire()
    {

        if (WeaponsManager.pistol == true)
        {

                isFiring = true;

                GameObject bullet = PoolManager.current.GetPooledObject("Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = bulletSpawn.position;
                    bullet.transform.rotation = bulletSpawn.rotation;
                    bullet.SetActive(true);

                }

                currentClip--;

                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().Play();
                }
                Invoke("SetFiring", fireTime);
        }

        else if (WeaponsManager.SMG == true)
        {
            if (currentClip1 <= 0 && maxAmmo1 <= 0)
            {
                isFiring = false;
                Debug.Log("You're out of ammo!");
            }

            else
            {
                isFiring = true;

                GameObject bullet = PoolManager.current.GetPooledObject("Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = bulletSpawn.position;
                    bullet.transform.rotation = bulletSpawn.rotation;
                    bullet.SetActive(true);

                }

                currentClip1--;

                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().Play();
                }
                Invoke("SetFiring", fireTime);
            }
        }

        else if (WeaponsManager.rifle == true)
        {
            if (currentClip2 <= 0 && maxAmmo2 <= 0)
            {
                isFiring = false;
                Debug.Log("You're out of ammo!");
            }

            else
            {
                isFiring = true;

                GameObject bullet = PoolManager.current.GetPooledObject("Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = bulletSpawn.position;
                    bullet.transform.rotation = bulletSpawn.rotation;
                    bullet.SetActive(true);

                }

                currentClip2--;

                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().Play();
                }
                Invoke("SetFiring", fireTime);
            }
        }
    }
    void Update()
    {

        if (Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
            return;
        }

        if (isReloading)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }

        if (currentClip <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        else if (currentClip1 <= 0 && WeaponsManager.SMG == true)
        {
            StartCoroutine(Reload());
            return;
        }

        else if (currentClip2 <= 0 && WeaponsManager.rifle == true)
        {
            StartCoroutine(Reload());
            return;
        }

    }

    IEnumerator Reload()
    {

        if (WeaponsManager.pistol == true)
        {
            isReloading = true;
            Debug.Log("Reloading...");
            yield return new WaitForSeconds(reloadTime);
            currentClip = maxClip;
            isReloading = false;
        }

        else if (WeaponsManager.SMG == true)
        {
            if (maxAmmo1 >= 30 && currentClip1 == 0)
            {
                isReloading = true;
                Debug.Log("Reloading...");
                yield return new WaitForSeconds(reloadTime);
                maxAmmo1 -= 10;
                currentClip1 = maxClip1;
                isReloading = false;
            }

            else if (maxAmmo1 >= 30 && currentClip1 > 0 && currentClip1 < 30)
            {
                isReloading = true;
                Debug.Log("Reloading...");
                yield return new WaitForSeconds(reloadTime);
                maxAmmo1 -= 30 - currentClip1;
                currentClip1 = maxClip1;
                isReloading = false;
            }

            else if (maxAmmo1 < 30 && maxAmmo1 > 0 && currentClip1 < 30)
            {
                isReloading = true;
                Debug.Log("Reloading...");
                yield return new WaitForSeconds(reloadTime);
                currentClip1 += maxAmmo1;
                if (currentClip1 > 30)
                {
                    maxAmmo1 = currentClip1 - 30;
                    currentClip1 = 30;
                }
                else
                {
                    maxAmmo1 = 0;
                }
                isReloading = false;
            }

            else if (maxAmmo1 < 30 && maxAmmo1 > 0 && currentClip1 == 0)
            {
                isReloading = true;
                Debug.Log("Reloading...");
                yield return new WaitForSeconds(reloadTime);
                currentClip1 = maxAmmo1;
                maxAmmo1 = 0;
                isReloading = false;
            }

            else if (currentClip1 == 30)
            {
                Debug.Log("You already have full ammo!");
            }

            else if (maxAmmo1 == 0)
            {
                Debug.Log("No spare ammo left!");
            }
        }

        else if (WeaponsManager.rifle == true)
        {
            if (maxAmmo2 > 0 && currentClip2 == 0)
            {
                isReloading = true;
                Debug.Log("Reloading...");
                yield return new WaitForSeconds(reloadTime);
                currentClip2 = maxClip2;
                isReloading = false;
                maxAmmo2--;
            }

            else if (currentClip2 > 0)
            {
                Debug.Log("You already have full ammo!");
            }

            else if (maxAmmo2 == 0)
            {
                Debug.Log("No spare ammo left!");
            }
        }
    }


}
