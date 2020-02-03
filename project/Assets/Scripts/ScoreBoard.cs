using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScore();
    }

    public void ScoreHit(int points) {
        score += points;
        UpdateScore();
    }
    private void UpdateScore() {
        scoreText.text = score.ToString();
    }
}
