using UnityEngine;
using TMPro;

public class Puntuación : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
