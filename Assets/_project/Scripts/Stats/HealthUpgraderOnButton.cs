using UnityEngine;

public class HealthUpgraderOnButton : StatsUpgraderOnButton
{
    public override void UpgradeStat()
    {
        if (CoinCounter.TotalCoinCount >= UpgradeCost)
        {
            ProgressService.GetProgress().Stats.UpgradeHealth();
            ProgressService.GetProgress().Counter.DecreaseCoin(UpgradeCost);
            UpdateDisplay();
            base.UpgradeStat();
        }
        else
        {
            ShowNotEnoghMoneyText();
        }
    }

    public override void UpdateDisplay()
    {
        CurrentStat.text = ProgressService.GetProgress().Stats.Health.ToString();
        NextLevelStat.text = $"{ProgressService.GetProgress().Stats.Health + ProgressService.GetProgress().Stats.UpgradeHealthCount}";
    }


}
