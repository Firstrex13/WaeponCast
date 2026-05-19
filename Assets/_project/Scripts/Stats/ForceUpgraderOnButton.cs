using UnityEngine;

public class ForceUpgraderOnButton : StatsUpgraderOnButton
{
    public override void UpgradeStat()
    {
        if (CoinCounter.TotalCoinCount >= UpgradeCost)
        {
            ProgressService.GetProgress().Stats.UpgradeForce();
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
        CurrentStat.text = ProgressService.GetProgress().Stats.Force.ToString();
        NextLevelStat.text = $"{ProgressService.GetProgress().Stats.Force + ProgressService.GetProgress().Stats.UpgradeForceCount}";
    }
}
