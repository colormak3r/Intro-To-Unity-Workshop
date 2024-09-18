using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum to represent the possible movement directions
public enum MoveDirection
{
    Left,
    Right
}

public class SimpleMove : MonoBehaviour
{
    // Public variables to configure the movement properties
    public MoveDirection moveDirection = MoveDirection.Left; // Direction of movement (default is Left)
    public float moveSpeed = 10f; // Speed of movement
    public float duration = 5f; // Duration before the object is destroyed
    public bool destroyOnHit = false; // Whether the object should be destroyed on collision

    // Private variables for internal use
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private float despawnTime; // Time at which the object should be destroyed

    // Start is called before the first frame update
    private void Start()
    {
        // Calculate the time when the object should despawn based on the duration
        despawnTime = Time.time + duration;

        // Get and cache the Rigidbody2D component for movement control
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Flip the object's scale based on the direction for visual effect
        transform.localScale = new Vector3((moveDirection == MoveDirection.Left ? -1 : 1), 1, 1);
    }

    // FixedUpdate is called at fixed intervals for physics-related updates
    private void FixedUpdate()
    {
        // Check if the object's lifetime has expired and destroy it if necessary
        if (Time.time > despawnTime && duration > 0)
            Destroy(gameObject);

        // Set the velocity based on the direction and speed
        rb.velocity = new Vector2((moveDirection == MoveDirection.Left ? -1 : 1) * moveSpeed, rb.velocity.y);
    }

    // This method is called when the object collides with another object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If destroyOnHit is enabled, destroy the object upon collision
        if (destroyOnHit)
            Destroy(gameObject);
    }
}

