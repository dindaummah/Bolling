using UnityEngine;
using UnityEngine.SceneManagement;

public class Ring : MonoBehaviour
{
    AudioManager audioManager;
    private Transform player;
    private Rigidbody playerRb;

    private bool canPlay = true;

    private void Start()
    {
        // Cari Player
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
            playerRb = p.GetComponent<Rigidbody>();
            if (playerRb == null)
                Debug.LogWarning("Player tidak memiliki Rigidbody!");
        }
        else
        {
            Debug.LogError("Player dengan tag 'Player' tidak ditemukan!");
        }

        // Cari AudioManager
        GameObject aObj = GameObject.FindGameObjectWithTag("Audio");
        if (aObj != null)
        {
            audioManager = aObj.GetComponent<AudioManager>();
        }

        if (audioManager == null)
        {
            Debug.LogError("AudioManager tidak ditemukan! Tambahkan tag 'Audio'.");
        }

        unlockedLevel();
    }

    void Update()
    {
        if (player == null || audioManager == null || playerRb == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        bool isFalling = playerRb.linearVelocity.y < 0;

        // ▶ Bunyi sekali per jatuhan
        if (distance < 6f && canPlay && isFalling)
        {
            audioManager.PlaySFX(audioManager.Bouncingball);
            canPlay = false;   // ← cegah double sound
        }

        // ▶ Reset ketika player tidak lagi jatuh (mulai naik / berhenti)
        if (!isFalling)
        {
            canPlay = true;
        }
    }

    void unlockedLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
