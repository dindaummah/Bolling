using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main menu"); // pakai nama scene persis sesuai di project
    }
}
