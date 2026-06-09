using System;

[Serializable]
public class PlayerStats
{
    private const string HEALTH_STAT = "_healthStat";
    private const string MANA_STAT = "_manaStat";
    private const string FORECE_STAT = "_forceStat";
    private const string ATTACK_RATE_STAT = "_attackRateStat";

    public int Health;
    public int Mana;
    public int Force;
    public float AttackRate;

    public int UpgradeHealthCount;
    public int UpgradeManaCount;
    public int UpgradeForceCount;
    public float UpgradeAttackRateCount;

    public PlayerStats(int health, int mana, int force, float attackRate, int upgadeHealthCount, int upgradeManaCount, int upgradeForceCount, float upgradeAttackRateCount)
    {
        Health = health;
        Mana = mana;
        Force = force;
        AttackRate = attackRate;
        UpgradeHealthCount = upgadeHealthCount;
        UpgradeManaCount = upgradeManaCount;
        UpgradeForceCount = upgradeForceCount;
        UpgradeAttackRateCount = upgradeAttackRateCount;
    }

    public void UpgradeStat(string stat)
    {
        switch (stat)
        {
            case HEALTH_STAT:
                Health += UpgradeHealthCount;
                break;
            case MANA_STAT:
                Mana += UpgradeManaCount;
                break;
            case FORECE_STAT:
                Force += UpgradeManaCount;
                break;
            case ATTACK_RATE_STAT:
                if (AttackRate >= 1f)
                {
                    return;
                }
                AttackRate += UpgradeAttackRateCount;
                break;

            default:
                break;
        }
    }
}