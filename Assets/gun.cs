using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunTransform;   // Reference to the gun's transform (where bullets will spawn)
    public GameObject bulletPrefab;  // Prefab of the bullet
    public float fireRate = 0.1f;    // Rate of fire (in seconds)
    public float bulletSpeed = 10f;  // Speed of the bullet
    public int magazineSize = 10;    // Number of bullets in a magazine
    public float reloadTime = 1.5f;   // Time it takes to reload (in seconds)

    private int currentAmmo;         // Current bullets in the magazine
    private bool isReloading = false; // Flag to check if the gun is currently reloading
    private float nextFireTime;      // Time of the next allowed shot

    private void Start()
    {
        currentAmmo = magazineSize;
    }

    private void Update()
    {
        if (isReloading)
            return;

        // Check if the player wants to shoot
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
}
