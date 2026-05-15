using UnityEngine;

public class ManaUpgraderOnButton : StatsUpgraderOnButton
{
    public override void UpgradeStat()
    {
        if (CoinCounter.TotalCoinCount >= UpgradeCost)
        {
            ProgressService.GetProgress().Stats.UpgradeMana();
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
        CurrentStat.text = ProgressService.GetProgress().Stats.Mana.ToString();
        NextLevelStat.text = $"{ProgressService.GetProgress().Stats.Mana + ProgressService.GetProgress().Stats.UpgradeManaCount}";
    }
}
