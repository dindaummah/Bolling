using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public void PilihSkin(int index)
{
    PlayerPrefs.SetInt("SkinIndex", index);
    PlayerPrefs.Save();
    Debug.Log("Skin dipilih (disimpan): " + index);
}
}
