using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;

    private void OnEnable()
    {
        _enemiesSpawner.AllEnemiesDefeated += OpenWinPanel;
    }

    private void OnDisable()
    {
        _enemiesSpawner.AllEnemiesDefeated += OpenWinPanel;
    }

    private void Start()
    {
        if(_winPanel.activeSelf)
        _winPanel.SetActive(false);
    }

    public void OpenMenu()
    {
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
    }

    public void CloseMenu()
    {
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OpenWinPanel()
    {
        _winPanel.SetActive(true);
    }
}
