using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;

    [Header("Preview Bola di Menu")]
    public Renderer modelBola;         // drag bola preview di hierarchy menu
    public Material[] listSkinBola;    // daftar material skin bola

    private int currentSkin;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        currentSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
        ApplyPreviewSkin(currentSkin);
    }

    public void GantiSkin(int index)
    {
        if (index < 0 || index >= listSkinBola.Length) return;

        currentSkin = index;

        // simpan pilihan skin agar bisa dipakai di level
        PlayerPrefs.SetInt("SelectedSkin", currentSkin);
        PlayerPrefs.Save();

        ApplyPreviewSkin(currentSkin);
    }

    private void ApplyPreviewSkin(int index)
    {
        if (modelBola != null)
        {
            modelBola.material = listSkinBola[index];
        }
    }

    public void NextSkin()
    {
        int newIndex = (currentSkin + 1) % listSkinBola.Length;
        GantiSkin(newIndex);
    }

    public void PrevSkin()
    {
        int newIndex = (currentSkin - 1 + listSkinBola.Length) % listSkinBola.Length;
        GantiSkin(newIndex);
    }
}
