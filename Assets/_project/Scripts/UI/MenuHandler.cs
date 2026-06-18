using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _title;
    [SerializeField] private TextMeshProUGUI _activeLevelNumberText;
    [SerializeField] private Image[] _activeLevelImages;

    private string _activeScene;

    private void Start()
    {
        if(_activeScene == null)
        {
            _activeScene = Scenes.LEVEL1;
        }

        ChooseActiveScene(_activeScene);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_activeScene);
    }

    public void ChooseActiveScene(string sceneName)
    {
        _activeScene = sceneName;

        if (_activeScene == Scenes.LEVEL1)
        {
            _activeLevelNumberText.text = "1";
            _activeLevelImages[1].color = Color.gray;
            _activeLevelImages[0].color = Color.green;
        }
        else if (_activeScene == Scenes.LEVEL2)
        {
            _activeLevelNumberText.text = "2";
            _activeLevelImages[1].color = Color.green;
            _activeLevelImages[0].color = Color.gray;
        }
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
    }
}
