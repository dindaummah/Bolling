using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Settings")]
    public AudioSource sumberSuara;
    public AudioClip bounceClip;

    [Header("Ball Reference")]
    public Rigidbody bola; // isi dari bola aktif (yang sedang dimainkan)

    private Vector3 lastVelocity; // menyimpan kecepatan sebelumnya

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (bola == null) return;

        // Deteksi pantulan: ketika arah kecepatan berubah dari turun ke naik (sumbu Y)
        if (lastVelocity.y < -0.1f && bola.linearVelocity.y > 0.1f)
        {
            // Volume sesuai dengan kekuatan pantulan
            float volume = Mathf.Clamp01(bola.linearVelocity.magnitude / 10f);

            // Sedikit variasi pitch agar suara lebih alami
            sumberSuara.pitch = Random.Range(0.9f, 1.1f);

            // Mainkan suara pantulan
            sumberSuara.PlayOneShot(bounceClip, volume);
        }

        lastVelocity = bola.linearVelocity;
    }

    public void KetikaSliderDiubah(float nilaiSlider)
    {
        sumberSuara.volume = nilaiSlider;
    }
}
