using System;

[Serializable]
public class PlayerStats
{
    private const string HEALTH_STAT = "_healthStat";
    private const string MANA_STAT = "_manaStat";
    private const string FORECE_STAT = "_forceStat";
    private const string ATTACK_RATE_STAT = "_attackRateStat";
    private const string MANA_RECOVERY_SPEED_STAT = "_manaRecoverySpeedStat";

    private float _upgradeCostMultiplier = 1.2f;

    public int Health;
    public int Mana;
    public int Force;
    public float AttackRate;
    public float ManaRecoverySpeed;

    public int UpgradeHealthCount;
    public int UpgradeManaCount;
    public int UpgradeForceCount;
    public float UpgradeAttackRateCount;
    public float UpgradeManaRecoverySpeedCount;

    public int UpgradeHealthCost = 5;
    public int UpgradeManaCost = 4;
    public int UpgradeForceCost = 6;
    public int UpgradeAttackRateCost = 8;
    public int UpgradeManaRecoverySpeedCost = 8;

    public float MaxAttackRateLevel = 1f;

    public PlayerStats(int health, int mana, float manaRecoverySpeed, int force, float attackRate, int upgadeHealthCount, int upgradeManaCount, int upgradeForceCount, float upgradeAttackRateCount, float manaRecoverySpeedCount)
    {
        Health = health;
        Mana = mana;
        ManaRecoverySpeed = manaRecoverySpeed;
        Force = force;
        AttackRate = attackRate;
        UpgradeHealthCount = upgadeHealthCount;
        UpgradeManaCount = upgradeManaCount;
        UpgradeForceCount = upgradeForceCount;
        UpgradeAttackRateCount = upgradeAttackRateCount;
        UpgradeManaRecoverySpeedCount = manaRecoverySpeedCount;
    }

    public void UpgradeStat(string stat)
    {
        switch (stat)
        {
            case HEALTH_STAT:
                Health += UpgradeHealthCount;
                UpgradeHealthCost = Convert.ToInt32(UpgradeHealthCost * _upgradeCostMultiplier);
                break;
            case MANA_STAT:
                Mana += UpgradeManaCount;
                UpgradeManaCost = Convert.ToInt32(UpgradeManaCost * _upgradeCostMultiplier);
                break;
            case FORECE_STAT:
                Force += UpgradeForceCount;
                UpgradeForceCost = Convert.ToInt32(UpgradeForceCost * _upgradeCostMultiplier);
                break;
            case ATTACK_RATE_STAT:
                if (AttackRate >= MaxAttackRateLevel)
                {
                    return;
                }

                AttackRate += UpgradeAttackRateCount;
                UpgradeAttackRateCost = Convert.ToInt32(UpgradeAttackRateCost * _upgradeCostMultiplier);
                break;
            case MANA_RECOVERY_SPEED_STAT:
                ManaRecoverySpeed += UpgradeManaRecoverySpeedCount;
                UpgradeManaRecoverySpeedCost = Convert.ToInt32(UpgradeManaRecoverySpeedCost * _upgradeCostMultiplier);
                break;
            default:
                break;
        }
    }
}