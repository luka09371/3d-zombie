using UnityEngine;
using UnityEngine.UI;

public class TargetAiScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Text healthText; // Reference to the regular Unity UI Text element

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Target destroyed!");
        Destroy(gameObject);
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
