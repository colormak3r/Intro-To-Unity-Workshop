using System.Collections;
using System.Collections.Generic;
using TMPro; // For using TextMeshPro UI elements
using UnityEngine;

public class EntityStatus : MonoBehaviour
{
    // Public variables to set max health and reference to UI text
    public int maxHealth = 10;
    public TMP_Text uiText; // Reference to TextMeshPro text for displaying health

    private int currentHealth; // The current health of the entity

    // Start is called before the first frame update
    private void Start()
    {
        OnSpawn(); // Initialize the entity's status when it spawns
    }

    // Method to handle damage taken by the entity
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease current health by damage amount
        if (uiText != null)
            uiText.text = "Health: " + currentHealth; // Update UI text if available

        if (currentHealth <= 0) // Check if health has dropped to 0 or below
        {
            Die(); // Trigger entity's death if health is depleted
        }
    }

    // Virtual method to handle entity's death (can be overridden in child classes)
    protected virtual void Die()
    {
        Destroy(gameObject); // Destroy the game object when it dies
    }

    // Method called on spawn to initialize entity health
    protected void OnSpawn()
    {
        currentHealth = maxHealth; // Set current health to max health
        if (uiText != null)
            uiText.text = "Health: " + currentHealth; // Update UI text if available
    }
}
