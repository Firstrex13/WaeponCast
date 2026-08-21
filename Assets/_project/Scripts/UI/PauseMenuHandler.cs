using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _BossUI;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private GameSaver _gameSaver;
    [SerializeField] private TextMeshProUGUI _winCoinsCount;
    [SerializeField] private TextMeshProUGUI _loseCoinsCount;

    [SerializeField] private PlayerHealth _playerHealth;

    private CoinCounter _coinCounter;
    private LevelManager _levelManager;
    private Leaderboard _leaderboard;

    private bool _bossIsActive;

    private void OnEnable()
    {
        _enemiesSpawner.AllEnemiesDefeated += OpenWinPanel;
        _playerHealth.Died += OpenLosePanel;
        _enemiesSpawner.BossSpawned += ActivateBossUI;
    }

    private void OnDisable()
    {
        _enemiesSpawner.AllEnemiesDefeated += OpenWinPanel;
        _playerHealth.Died -= OpenLosePanel;
        _enemiesSpawner.BossSpawned -= ActivateBossUI;
    }

    private void Start()
    {
        if (_winPanel.activeSelf)
            _winPanel.SetActive(false);

        if (_losePanel.activeSelf)
            _losePanel.SetActive(false);

        _bossIsActive = false;
    }

    [Inject]
    public void Construct(Player player, IProgressService progress)
    {
        _playerHealth = player.GetComponent<PlayerHealth>();
        _coinCounter = progress.GetProgress().Counter;
        _levelManager = progress.GetProgress().LevelManager;
        _leaderboard = progress.GetProgress().Leaderboard;
    }

    public void OpenMenu()
    {
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
        DeactivateBossUI();
    }

    public void CloseMenu()
    {
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);

        if (_bossIsActive)
        {
            ActivateBossUI();
        }
    }

    public void ReturnToMenu()
    {
        _gameSaver.SaveGame();
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    public void ReturnToMenuAfterWin()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        _coinCounter.AddCoinsToTotalCount();

        YG2.SetLeaderboard("LeaderboardDesk", _coinCounter.TotalCoins);

        if (nextIndex < Scenes.SceneNames.Length && (SceneManager.GetActiveScene().buildIndex - 1) == _levelManager.CountOfOpenedLevels)
        {
            _levelManager.OpenNextLevel();
        }

        _gameSaver.SaveGame();
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    public void ReturnToMenuAfterLose()
    {
        _coinCounter.AddCoinsToTotalCount();
        _gameSaver.SaveGame();
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    public void RestartLevel()
    {
        _coinCounter.AddCoinsToTotalCount();
        _gameSaver.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OpenWinPanel()
    {
        _winPanel.SetActive(true);
        _winCoinsCount.text = _coinCounter.CoinCountOnLevel.ToString();
        _pauseButton.SetActive(false);
        DeactivateBossUI();
    }

    private void OpenLosePanel()
    {
        _losePanel.SetActive(true);
        _loseCoinsCount.text = _coinCounter.CoinCountOnLevel.ToString();
        _pauseButton.SetActive(false);
        DeactivateBossUI();
    }

    private void ActivateBossUI()
    {
        if (_bossIsActive == false)
        {
            _bossIsActive = true;
        }

        _BossUI.SetActive(true);
    }

    private void DeactivateBossUI()
    {
        _BossUI.SetActive(false);
    }
}
