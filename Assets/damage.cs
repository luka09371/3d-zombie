// BulletScript.cs
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage = 10; // Adjust the damage value as needed

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with is a target
        TargetAiScript target = collision.gameObject.GetComponent<TargetAiScript>();
        if (target != null)
         
        {
            // Deal damage to the target
            target.TakeDamage(damage);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
   
}
