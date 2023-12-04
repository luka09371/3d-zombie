using UnityEngine;

public class AIShooting : MonoBehaviour
{
    public Transform shootingPoint;  // Point where bullets will be spawned
    public GameObject bulletPrefab;  // Prefab of the bullet
    public float fireRate = 1f;      // Rate of fire (bullets per second)
    public float bulletSpeed = 10f;  // Speed of the bullet

    private float nextFireTime;      // Time of the next allowed shot

    void Update()
    {
        // Check if it's time to shoot
        if (Time.time > nextFireTime)
        {
            // Find the target object with TargetScript attached
            GameObject targetObject = FindTargetObject();

            // Call the Shoot method to spawn a bullet at the target object
            Shoot(targetObject);

            // Update the next allowed shot time based on fire rate
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot(GameObject target)
    {
        if (target != null)
        {
            // Calculate the direction from the AI to the target
            Vector3 shootDirection = (target.transform.position - shootingPoint.position).normalized;

            // Instantiate a bullet at the shooting point
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.LookRotation(shootDirection));

            // Apply force to the bullet (if using Rigidbody)
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;

            // Attempt to call TakeDamage on the target if it has the TargetScript
            TargetScript targetScript = target.GetComponent<TargetScript>();
            if (targetScript != null)
            {
                // Assume the bullet has a damage value
                int bulletDamage = 1;
                targetScript.TakeDamage(bulletDamage);
            }
        }
    }

    GameObject FindTargetObject()
    {
        // Implement a method to find and return the target object based on your game logic
        // For example, you might use tags or layers to identify target objects.
        // This method will vary based on your specific game structure.
        // For simplicity, this example returns the first GameObject with the "Target" tag.

        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Target");

        if (targetObjects.Length > 0)
        {
            return targetObjects[0];
        }

        return null;
    }
}
