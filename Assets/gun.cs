// GunWithMagazine.cs
using System.Collections;
using UnityEngine;

public class GunWithMagazine : MonoBehaviour
{
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int magazineSize = 10;
    public float fireRate = 0.5f;
    public float reloadTime = 2f;

    private int currentAmmo;
    private bool isReloading = false;
    private float nextFireTime;

    private void Start()
    {
        currentAmmo = magazineSize;
    }

    private void Update()
    {
        if (isReloading)
            return;

        // Check if the player wants to shoot continuously while holding the button
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }

        // Check if the player wants to reload
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < magazineSize)
        {
            StartCoroutine(Reload());
        }
    }

    private void Shoot()
    {
        if (currentAmmo > 0)
        {
            // Instantiate a bullet
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);

            // Attach the BulletScript to the bullet
            BulletScript bulletScript = bullet.AddComponent<BulletScript>();
            bulletScript.damageAmount = 0; // Corrected line

            // Apply force to the bullet
            bullet.GetComponent<Rigidbody>().velocity = gunTransform.forward * bulletSpeed;

            // Decrease ammo count
            currentAmmo--;
        }
        else
        {
            // If out of ammo, play a reload sound or display a message
            Debug.Log("Out of ammo! Reload!");
        }
    }


    private IEnumerator Reload()
    {
        isReloading = true;

        // Play reload animation or sound

        yield return new WaitForSeconds(reloadTime);

        // Refill ammo
        currentAmmo = magazineSize;
        isReloading = false;
    }

    // Public method to change the magazine size externally
    public void ChangeMagazineSize(int newSize)
    {
        magazineSize = newSize;
        currentAmmo = magazineSize; // Refill the magazine when changing its size
    }
}
