using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private GameSaver _gameSaver;

    [SerializeField] private PlayerHealth _playerHealth;

    private CoinCounter _coinCounter;

    private void OnEnable()
    {
        _enemiesSpawner.AllEnemiesDefeated += OpenWinPanel;
        _playerHealth.Died += OpenLosePanel;
    }

    private void OnDisable()
    {
        _enemiesSpawner.AllEnemiesDefeated += OpenWinPanel;
        _playerHealth.Died -= OpenLosePanel;
    }

    private void Start()
    {
        if (_winPanel.activeSelf)
            _winPanel.SetActive(false);

        if (_losePanel.activeSelf)
            _losePanel.SetActive(false);
    }

    [Inject]
    public void Construct(Player player, CoinCounter coinCounter)
    {
        _playerHealth = player.GetComponent<PlayerHealth>();
        _coinCounter = coinCounter;
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

    public void ReturnToMenuAfterWin()
    {
        _coinCounter.AddCoinsToTotalCount();
        _gameSaver.SaveGame();
        SceneManager.LoadScene("MainMenu");
    }

    private void OpenWinPanel()
    {
        _winPanel.SetActive(true);
    }

    private void OpenLosePanel()
    {
        _losePanel.SetActive(true);
    }
}
