using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damageAmount = 10; // Adjust the damage value as needed

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the TargetAiScript
        TargetAiScript target = collision.gameObject.GetComponent<TargetAiScript>();

        if (target != null)
        {
            // Call TakeDamage on the target
            target.TakeDamage(damageAmount);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
