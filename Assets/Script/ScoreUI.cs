using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [Header("UI Text References")]
    public TMP_Text scoreText;       // Drag teks "Score" ke sini
    public TMP_Text highScoreText;   // Drag teks "High Score" ke sini

    private void Start()
    {
        // Cek apakah ScoreManager ada di scene
        if (ScoreManager.Instance == null)
        {
            Debug.LogError("ScoreManager tidak ditemukan di scene!");
            return;
        }

        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.score;
        highScoreText.text = "Highscore: " + ScoreManager.Instance.highScore;
    }
}
