using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    public static bool IsGamePaused { get; private set; }
    public void Activate(int score)
    {
        IsGamePaused = true;
        Time.timeScale = 0f;
        gameObject.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore", score);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        } 

        _scoreText.text =
            "Score: " + score + "\n" +
            "Best: " + highScore;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        IsGamePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        IsGamePaused = false;
    }
}
