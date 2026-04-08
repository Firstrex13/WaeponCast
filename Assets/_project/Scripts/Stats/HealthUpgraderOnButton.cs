public class HealthUpgraderOnButton : StatsUpgraderOnButton
{
    public override void UpgradeStat()
    {
        PlayerData.Stats.UpgradeHealth();
        base.UpgradeStat();
    }

    public override void UpdateDisplay()
    {
        CurrentStat.text = PlayerData.Stats.Health.ToString();
        NextLevelStat.text = $"{PlayerData.Stats.Health + 10}";
    }
}
