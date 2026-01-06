using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isLevelWin = false;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject levelWin;

    void Start()
    {
        isGameOver = false;
        isLevelWin = false;

        Time.timeScale = 1f;

        if (gameOver != null) gameOver.SetActive(false);
        if (levelWin != null) levelWin.SetActive(false);
    }

    void Update()
    {
        if (isGameOver)
        {
            if (gameOver != null) gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (isLevelWin)
        {
            if (levelWin != null) levelWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver dipanggil");
        isGameOver = true;
    }

    public void LevelWin()
    {
        Debug.Log("LevelWin dipanggil");
        isLevelWin = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
