using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _title;
    [SerializeField] private Button[] _levelButtons;

    private string _activeScene;
    private IProgressService _playerProgress;


    [Inject]
    public void Construct(IProgressService playerProgress)
    {
        _playerProgress = playerProgress;
    }

    public void StartGame()
    {
        ChooseActiveScene(_activeScene);
        SceneManager.LoadScene(_activeScene);
    }

    public void ChooseActiveScene(string sceneName)
    {
        _activeScene = sceneName;
    }

    public void OpenSkillsPenal()
    {
        _menuPanel.SetActive(false);
        _player.gameObject.SetActive(false);
        _title.SetActive(false);

        _levelUpPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        if (_levelUpPanel.activeSelf)
        {
            _levelUpPanel.SetActive(false);
            _menuPanel.SetActive(true);
            _player.gameObject.SetActive(true);
            _title.SetActive(true);

        }
        else if (_settingsPanel.activeSelf)
        {
            _settingsPanel.SetActive(false);
            _menuPanel.SetActive(true);
            _player.gameObject.SetActive(true);
            _title.SetActive(true);
        }
        else if (_levelsPanel.activeSelf)
        {
            _levelsPanel.SetActive(false);
            _menuPanel.SetActive(true);
            _player.gameObject.SetActive(true);
            _title.SetActive(true);
        }
    }

    public void OpenSettingsPanel()
    {
        _menuPanel.SetActive(false);
        _title.SetActive(false);
        _player.gameObject.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void OpenLevelsPanel()
    {
        _menuPanel.SetActive(false);
        _title.SetActive(false);
        _player.gameObject.SetActive(false);
        _levelsPanel.SetActive(true);

        for (int i = 0; i < _playerProgress.GetProgress().LevelManager.CountOfOpenedLevels; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
}
