using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _player;
    [SerializeField] private StatsUpgraderOnButton[] _statsUpgraders;

    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSkillsPenal()
    {
        _menuPanel.SetActive(false);
        _player.gameObject.SetActive(false);

        _levelUpPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        if (_levelUpPanel.activeSelf)
        {
            _levelUpPanel.SetActive(false);
            _menuPanel.SetActive(true);
            _player.gameObject.SetActive(true);
        }
        else if (_settingsPanel.activeSelf)
        {
            _settingsPanel.SetActive(false);
            _menuPanel.SetActive(true);
            _player.gameObject.SetActive(true);
        }
    }

    public void OpenSettingsPanel()
    {
        _menuPanel.SetActive(false);
        _player.gameObject.SetActive(false);
        _settingsPanel.SetActive(true);
    }
}
