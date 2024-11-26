using UnityEngine;
using UnityEngine.UI;

/**
 * Manages the player's score and persists it across scenes.
 * Implements a singleton pattern for easy access from other scripts.
 * I learned from here: https://www.youtube.com/watch?v=YUcvy9PHeXs&t=210s&ab_channel=CocoCode
*/

// How to save the points to the next scene 
public class ScoreManager : MonoBehaviour
{
    // The singleton instance of ScoreManager.
    public static ScoreManager instance;

    [Tooltip("UI Text element to display the current score.")]
    public Text scoreText;

    public int score = 0; // The current score of the player.

    /*
     * Called when the script instance is being loaded.
     * Sets up the singleton instance and prevents this object from being destroyed on scene load.
     */
    private void Awake()
    {

        // Ensures only one ScoreManager exists and persists across scene loads
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate instances
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = " POINTS: " + score.ToString();
    }

    // Increases the score by one and updates the score displayed on the UI.
    public void AddPoint()
    {
        score++;
        scoreText.text = " POINTS: " + score.ToString();
    }
}