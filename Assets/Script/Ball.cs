using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float bounceForce = 400f;

     [Header("Skin Settings (Prefab Bola)")]
    public Material[] listSkinBola; 
    public Renderer ballRenderer;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        ApplySkin();
    }

     private void ApplySkin()
    {
        // Ambil skin yang dipilih terakhir
        int selectedSkin = PlayerPrefs.GetInt("SelectedSkin", 0);

        // Ambil Renderer dari child bola
        Renderer rend = GetComponentInChildren<Renderer>();

        if (rend != null && SkinManager.Instance != null)
        {
            // Ambil material dari SkinManager (bukan dari prefab)
            rend.sharedMaterial = SkinManager.Instance.listSkinBola[selectedSkin];
            Debug.Log("Skin bola terpasang: index " + selectedSkin);
        }
        else
        {
            Debug.LogWarning("SkinManager.Instance atau Renderer tidak ditemukan!");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Bounce
        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            bounceForce * Time.deltaTime,
            rb.linearVelocity.z
        );

        // Cek collision
        if (other.gameObject.CompareTag("Safe"))
        {
               Debug.Log("YOU ARE SAFE");
        }
        else if (other.gameObject.CompareTag("UnSafe"))
        {
            Debug.Log("GAME OVER");
            GameManager.isGameOver = true;
        }
        else if (other.gameObject.CompareTag("GoalZone"))
        {
            Debug.Log("LEVEL WIN");
            GameManager.isLevelWin = true;
        }
    }
}
