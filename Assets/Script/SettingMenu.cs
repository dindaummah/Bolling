using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] GameObject settingMenu; // Panel Setting

    public void OpenSetting()
    {
        settingMenu.SetActive(true);
    }

    public void CloseSetting()
    {
        settingMenu.SetActive(false);
    }
}
