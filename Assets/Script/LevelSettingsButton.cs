using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelToSettings : MonoBehaviour
{
    public void BukaSettings()
    {
        // Set flag supaya Menu tahu kita ingin langsung buka panel Settings
        PlayerPrefs.SetInt("OpenSettings", 1);
        PlayerPrefs.Save();

        // Load scene Menu
        SceneManager.LoadScene("MenuScene");
    }
}
