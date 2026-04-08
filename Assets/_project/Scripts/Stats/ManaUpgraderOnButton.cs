public class ManaUpgraderOnButton : StatsUpgraderOnButton
{
    public override void UpgradeStat()
    {
        PlayerData.Stats.UpgradeMana();
        base.UpgradeStat();
    }

    public override void UpdateDisplay()
    {
        CurrentStat.text = PlayerData.Stats.Mana.ToString();
        NextLevelStat.text = $"{PlayerData.Stats.Mana + 5}";
    }
}
