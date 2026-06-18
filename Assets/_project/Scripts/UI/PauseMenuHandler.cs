using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField] private PlayerHealth _playerHealth;

    private CoinCounter _coinCounter;

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
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnToMenuAfterWin()
    {
        _coinCounter.AddCoinsToTotalCount();
        _gameSaver.SaveGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnToMenuAfterLose()
    {
        _coinCounter.AddCoinsToTotalCount();
        _gameSaver.SaveGame();
        SceneManager.LoadScene("MainMenu");
    }

    private void OpenWinPanel()
    {
        _winPanel.SetActive(true);
        _pauseButton.SetActive(false);
        DeactivateBossUI();
    }

    private void OpenLosePanel()
    {
        _losePanel.SetActive(true);
        _pauseButton.SetActive(false);
        DeactivateBossUI();
    }

    private void ActivateBossUI()
    {
        if(_bossIsActive == false)
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
