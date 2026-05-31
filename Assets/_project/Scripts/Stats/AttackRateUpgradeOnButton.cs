
using UnityEngine;

public class AttackRateUpgradeOnButton : StatsUpgraderOnButton
{
    public override void UpgradeStat()
    {
        if (CoinCounter.TotalCoinCount >= UpgradeCost)
        {
            ProgressService.GetProgress().Stats.UpgradeAttackRate();
            ProgressService.GetProgress().Counter.DecreaseCoin(UpgradeCost);
            UpdateDisplay();
            base.UpgradeStat();
        }
        else
        {
            Debug.Log("Недостаточно монет");
        }
    }

    public override void UpdateDisplay()
    {
        CurrentStat.text = ProgressService.GetProgress().Stats.AttackRate.ToString();
        NextLevelStat.text = $"{ProgressService.GetProgress().Stats.AttackRate + ProgressService.GetProgress().Stats.UpgradeAttackRateCount}";
    }
}
