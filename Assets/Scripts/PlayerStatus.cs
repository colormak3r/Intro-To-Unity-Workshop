using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : EntityStatus
{
    // Reference to the player's respawn point
    public Transform spawnPoint;

    // Override the Die method from the base EntityStatus class
    protected override void Die()
    {
        // Move the player to the respawn point when they "die"
        transform.position = spawnPoint.position;

        // Reset the player's health and update UI, simulating a respawn
        OnSpawn();
    }
}

