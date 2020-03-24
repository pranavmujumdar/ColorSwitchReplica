using UnityEngine;
using TMPro;
/// <summary>
/// This Class used for tracking the score and changing the scoretext
/// </summary>
public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //Init score to 0
    private float score = 0f;
    /// <summary>
    /// Setting score at the start of the game
    /// </summary>
    void Start()
    {
        SetScore();
    }

    /// <summary>
    /// Updating score when the player's Y position is more than score
    /// </summary>
    void FixedUpdate()
    {
        if (transform.position.y > score)
        {
            score = transform.position.y;
            SetScore();
        }
       
    }
    /// <summary>
    /// Sets the score to the text field
    /// </summary>
    void SetScore()
    {
        scoreText.text = score.ToString("0");
    }
}
