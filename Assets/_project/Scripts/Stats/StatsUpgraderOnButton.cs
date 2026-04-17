using TMPro;
using UnityEngine;

public class StatsUpgraderOnButton : MonoBehaviour
{
    [SerializeField] private GameSaver _saver;
    [SerializeField] protected TextMeshProUGUI CurrentStat;
    [SerializeField] protected TextMeshProUGUI NextLevelStat;

    public virtual void UpgradeStat()
    {
        UpdateDisplay();
        _saver.SaveGame();
    }

    public virtual void UpdateDisplay() { }
}
