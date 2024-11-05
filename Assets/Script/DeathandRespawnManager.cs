using UnityEngine;
using TMPro; // Using TextMesh Pro namespace for UI

public class DeathAndRespawnManager : MonoBehaviour
{
    public int deaths = 0; // Variable to keep track of deaths
    public TMP_Text deathText; // TextMesh Pro UI element to display death count
    public float threshold; // Y-axis threshold below which the player is considered "dead"
    public Transform playerTransform; // Reference to the player's Transform component

    private void Awake()
    {
        // Load saved death count
        deaths = PlayerPrefs.GetInt("Deaths", 0);
    }

    void Start()
    {
        UpdateUI(); // Initialize the UI with current death counts
    }

    public void IncreaseDeaths()
    {
        deaths++; // Increment the death count
        PlayerPrefs.SetInt("Deaths", deaths); // Save death count
        UpdateUI(); // Update the UI to reflect the new death count
    }

    public void IncreaseRespawns()
    {
        // Increment the respawn count (if you still want to track it internally but not display)
        PlayerPrefs.SetInt("Respawns", PlayerPrefs.GetInt("Respawns", 0) + 1);
    }

    void FixedUpdate()
    {
        // Check if the player's position is below the threshold
        if (playerTransform.position.y < threshold)
        {
            PlayerDeath(); // Call the method to handle player death
            PlayerRespawn(); // Call the method to handle player respawn
            // Reset player's position to a specific point
            playerTransform.position = new Vector3(0.41f, 2.32f, 0.005f);
        }
    }

    void UpdateUI()
    {
        // Update the TextMesh Pro UI element with the current death count
        deathText.text = "Deaths: " + deaths;
    }

    void PlayerDeath()
    {
        IncreaseDeaths(); // Increment the death count
    }

    void PlayerRespawn()
    {
        IncreaseRespawns(); // Increment the respawn count internally
    }

    void OnApplicationQuit()
    {
        // Reset death count to zero when the application quits
        PlayerPrefs.SetInt("Deaths", 0);
        // Reset respawn count to zero when the application quits
        PlayerPrefs.SetInt("Respawns", 0);
    }
}


