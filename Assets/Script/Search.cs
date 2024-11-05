using UnityEngine;

public class Search : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Transform enemy; // Reference to the enemy's transform

    void Update()
    {
        // Calculate the direction vector from player to enemy and normalize it
        Vector3 toEnemy = (enemy.position - player.position).normalized;

        // Calculate the dot product between the player's forward direction and the direction to the enemy
        float dot = Vector3.Dot(player.forward, toEnemy);

        // Check and log the relation based on the dot product value
        if (dot > 0.5f)
        {
            Debug.Log("Enemy is within the player's field of view.");
        }
        else if (Mathf.Approximately(dot, 0))
        {
            Debug.Log("Enemy is perpendicular to the player's view.");
        }
        else if (dot < 0)
        {
            Debug.Log("Enemy is behind the player.");
        }
    }
}

