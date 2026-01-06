using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")  ]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("-----Audio Clips-----")]
    public AudioClip Bouncingball;

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
