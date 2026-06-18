using System;

[Serializable]
public class PlayerStats
{
    private const string HEALTH_STAT = "_healthStat";
    private const string MANA_STAT = "_manaStat";
    private const string FORECE_STAT = "_forceStat";
    private const string ATTACK_RATE_STAT = "_attackRateStat";
    private const string MANA_RECOVERY_SPEED_STAT = "_manaRecoverySpeedStat";

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
                break;
            case MANA_STAT:
                Mana += UpgradeManaCount;
                break;
            case FORECE_STAT:
                Force += UpgradeForceCount;
                break;
            case ATTACK_RATE_STAT:
                if (AttackRate >= MaxAttackRateLevel)
                {
                    return;
                }

                AttackRate += UpgradeAttackRateCount;
                break;
            case MANA_RECOVERY_SPEED_STAT:
                ManaRecoverySpeed += UpgradeManaRecoverySpeedCount;
                break;
            default:
                break;
        }
    }
}