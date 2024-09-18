using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    // Public variable to set the amount of damage dealt
    public int damage = 1;

    // This method is called when another object enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that collided has the EntityStatus component
        // If it does, store it in the variable 'entityStatus'
        if (collision.TryGetComponent<EntityStatus>(out var entityStatus))
            // Call the TakeDamage method on the entity to apply damage
            entityStatus.TakeDamage(damage);
    }
}

