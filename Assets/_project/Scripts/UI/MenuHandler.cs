using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpPanel;
    [SerializeField] private GameObject _menuPanel;
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

        //foreach (var stat in _statsUpgraders)
        //{
        //    stat.RefreshStatsView();
        //}

        _levelUpPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        _levelUpPanel.SetActive(false);
        _menuPanel.SetActive(true);
        _player.gameObject.SetActive(true);
    }
}
