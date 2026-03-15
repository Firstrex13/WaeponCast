using UnityEngine;

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
}
