using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject _levelUpPanel;
    [SerializeField] GameObject _menuPanel;

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
        _levelUpPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        _levelUpPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }
}
