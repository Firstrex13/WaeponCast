using TMPro;
using UnityEngine;
using Zenject;

public class StatsUpgraderOnButton : MonoBehaviour
{
    [SerializeField] private GameSaver _saver;
    [SerializeField] protected int UpgradeCost;
    [SerializeField] protected TextMeshProUGUI CurrentStat;
    [SerializeField] protected TextMeshProUGUI NextLevelStat;
    [SerializeField] protected TextMeshProUGUI NotEnoughCoinsText;

    protected IProgressService ProgressService;
    protected CoinCounter CoinCounter;

    public virtual void UpgradeStat()
    {
        _saver.SaveGame();
    }

    public virtual void UpdateDisplay() { }

    [Inject]
    public void Construct(IProgressService progress)
    {
        ProgressService = progress;
        CoinCounter = progress.GetProgress().Counter;
    }
}
