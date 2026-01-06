using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSettingsButton : MonoBehaviour
{
    public void BukaSettingsDiMenu()
    {
        // Set flag bahwa kita ingin membuka settings
        PlayerPrefs.SetInt("OpenSettings", 1);
        PlayerPrefs.Save();

        // Pindah ke scene Menu
        SceneManager.LoadScene("MenuScene");
    }
}
