using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Reference to the GameObject that contains the winning text (UI element)
    public GameObject winningTextPanel;

    // This method is triggered when another object enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Activate the winning text when the player or object reaches the goal
        winningTextPanel.SetActive(true);
    }
}

