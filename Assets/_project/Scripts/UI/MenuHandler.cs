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
    [SerializeField] private GameObject _lightningButton;
    [SerializeField] private GameObject _fireballButton;
    [SerializeField] private GameObject _leaderboard;
    [SerializeField] private Button[] _levelButtons;
    [SerializeField] private Button[] _weaponButtons;

    private string _activeScene;
    private IProgressService _playerProgress;
    private LevelManager _levelManager;


    [Inject]
    public void Construct(IProgressService playerProgress)
    {
        _playerProgress = playerProgress;
        _levelManager = _playerProgress.GetProgress().LevelManager;
    }

    public void StartGame()
    {
        ChooseActiveScene(_activeScene);
        _levelManager.SetCurrentLevel(_activeScene);
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
        _leaderboard.SetActive(false);

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
            _leaderboard.SetActive(true);

        }
        else if (_settingsPanel.activeSelf)
        {
            _settingsPanel.SetActive(false);
            _menuPanel.SetActive(true);
            _player.gameObject.SetActive(true);
            _title.SetActive(true);
            _leaderboard.SetActive(true);
        }
        else if (_levelsPanel.activeSelf)
        {
            _levelsPanel.SetActive(false);
            _menuPanel.SetActive(true);
            _player.gameObject.SetActive(true);
            _title.SetActive(true);
            _leaderboard.SetActive(true);
        }
    }

    public void OpenSettingsPanel()
    {
        _menuPanel.SetActive(false);
        _title.SetActive(false);
        _player.gameObject.SetActive(false);
        _leaderboard.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void OpenLevelsPanel()
    {
        _menuPanel.SetActive(false);
        _title.SetActive(false);
        _player.gameObject.SetActive(false);
        _leaderboard.SetActive(false);
        _levelsPanel.SetActive(true);

        int basicOuntLevels = 1;

        if (_playerProgress.GetProgress().LevelManager.CountOfOpenedLevels == 0)
        {
            for (int i = 0; i < basicOuntLevels; i++)
            {
                _levelButtons[i].interactable = true;
            }
        }
        else
        {
            for (int i = 0; i < _playerProgress.GetProgress().LevelManager.CountOfOpenedLevels; i++)
            {
                _levelButtons[i].interactable = true;
            }
        }
    }

    public void OpenCloseWeaponsButtons()
    {
        if (!_lightningButton.activeSelf)
        {
            _lightningButton.SetActive(true);
        }
        else
        {
            _lightningButton.SetActive(false);
        }

        if (!_fireballButton.activeSelf)
        {
            _fireballButton.SetActive(true);
        }
        else
        {
            _fireballButton.SetActive(false);
        }

        for (int i = 0; i < _playerProgress.GetProgress().LevelManager.CountOfOpenedLevels; i++)
        {
            if (_playerProgress.GetProgress().LevelManager.CountOfOpenedLevels >= 2)
            {
                _weaponButtons[1].interactable = true;

            }
        }
    }
}
