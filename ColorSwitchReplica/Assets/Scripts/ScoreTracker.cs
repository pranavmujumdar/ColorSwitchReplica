using UnityEngine;
using TMPro;
public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > score)
        {
            score = transform.position.y;
            SetScore();
        }
       
    }

    void SetScore()
    {
        scoreText.text = score.ToString("0");
    }
}
