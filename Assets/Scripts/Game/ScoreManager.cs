using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highScore;
    public TMP_Text scoreText, highscoreText, gameOverScoreText, gameoverHighScoreText;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highscoreText.text = highScore.ToString();
            gameoverHighScoreText.text = highScore.ToString();
        }
    }
    public void AddScore()
    {
        score++;
        UpdateHighScore();
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
    }
    public void MinusScore()
    {
        score -= 1;
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
    }
    public void Minus2Score()
    {
        score -= 2;
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
    }
    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highscoreText.text = highScore.ToString();
            gameoverHighScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
    }
    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highscoreText.text = highScore.ToString();
        gameoverHighScoreText.text = highScore.ToString();
    }
}