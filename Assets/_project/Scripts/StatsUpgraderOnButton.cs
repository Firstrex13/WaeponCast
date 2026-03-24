using TMPro;
using UnityEngine;

public class StatsUpgraderOnButton : MonoBehaviour
{
    [SerializeField] private Saver _saver;
    [SerializeField] private TextMeshProUGUI _currentHealthStat;
    [SerializeField] private TextMeshProUGUI _nextHealthLevelStat;
    [SerializeField] private TextMeshProUGUI _currentManaStat;
    [SerializeField] private TextMeshProUGUI _nextManaLevelStat;

    public void UpgradeHealthStat()
    {
        PlayerData.Stats.UpgradeHealth();
        UpdateHealthDisplay();
        _saver.SaveGame();
    }

    public void UpgradeManaStat()
    {
        PlayerData.Stats.UpgradeMana();
        UpdateManaDisplay();
        _saver.SaveGame();
    }

    public void UpdateHealthDisplay()
    {
        _currentHealthStat.text = PlayerData.Stats.Health.ToString();
        _nextHealthLevelStat.text = $"{PlayerData.Stats.Health + 10}";
    }

    public void UpdateManaDisplay()
    {
        _currentManaStat.text = PlayerData.Stats.Mana.ToString();
        _nextManaLevelStat.text = $"{PlayerData.Stats.Mana + 5}";
    }
}
