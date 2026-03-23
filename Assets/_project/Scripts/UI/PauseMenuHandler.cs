using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public void OpenMenu()
    {
        _pauseMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        _pauseMenu.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
