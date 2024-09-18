using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    // Public variable to specify the prefab to spawn
    public GameObject prefab;

    // Time interval between spawns
    public float cooldown = 5f;

    // Private variable to track when the next spawn can occur
    private float nextSpawn;

    // Update is called once per frame
    private void Update()
    {
        // Check if the current time has passed the next spawn time
        if (Time.time > nextSpawn)
        {
            // Update the next spawn time by adding the cooldown period
            nextSpawn = Time.time + cooldown;

            // Instantiate (spawn) the prefab at the current object's position with no rotation
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}

