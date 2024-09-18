using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Reference to the bullet prefab to be instantiated when firing
    [SerializeField]
    private GameObject bulletPrefab;

    // Reference to the nozzle (or gun barrel) where the bullet will be spawned
    [SerializeField]
    private Transform nozzle;

    // Update is called once per frame
    private void Update()
    {
        // Check if the player presses the fire button (usually left-click or "Fire1")
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the bullet at the nozzle's position with no rotation
            var bullet = Instantiate(bulletPrefab, nozzle.position, Quaternion.identity);

            // Determine the player's facing direction based on the localScale.x (1 for right, -1 for left)
            var facing = transform.localScale.x;

            // Set the bullet's move direction based on the player's facing direction
            bullet.GetComponent<SimpleMove>().moveDirection = facing == 1 ? MoveDirection.Right : MoveDirection.Left;
        }
    }
}

