using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score { get; private set; } = 0;
    public int highScore { get; private set; } = 0;

    private const string HighScoreKey = "HighScore";

    void Awake()
    {
        // Singleton sederhana
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   // opsional (agar tidak hilang antar scene)
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Ambil highscore tersimpan
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    // Tambah score
    public void AddScore(int amount = 1)
    {
        score += amount;

        // Cek apakah highscore baru
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();
        }
    }

    // Reset score saat mulai level baru
    public void ResetScore()
    {
        score = 0;
    }

    // Pastikan highscore tersimpan saat game over
    public void OnGameOver()
    {
        if (score > PlayerPrefs.GetInt(HighScoreKey, 0))
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
            highScore = score;
        }
    }

    // Reset highscore manual
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(HighScoreKey);
        highScore = 0;
    }
}
